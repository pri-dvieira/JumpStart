using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Data;
using Primavera.Bot.Entities;
using Primavera.Bot.Entities.Results;
using Primavera.Bot.Managers.Interfaces;
using Primavera.Hurakan.BotHandlers;
using Primavera.Hurakan.Core;
using Primavera.Hurakan.Handlers;

namespace Primavera.Bot.PDEXTopic
{
    /// <summary>
    /// This is the class that implements the topic handler to produce template messages.
    /// </summary>
    /// <seealso cref="Primavera.Hurakan.BotHandlers.TopicHandlerBase" />
    [Export(typeof(IHandler))]
    [Export(typeof(PDEXHandler))]
    public class PDEXHandler : TopicHandlerBase
    {
        #region Private Members

        private bool hasContext = false;
        string strTopicId = string.Empty;
        string strTaskId = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PDEXTopic"/> class.
        /// </summary>
        public PDEXHandler() : base()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string assemblyFullName;

            System.Reflection.AssemblyName assemblyName;

            const string PRIMAVERA_FOLDER = "PRIMAVERA\\SG100\\Apl\\PDEX";

            assemblyName = new System.Reflection.AssemblyName(args.Name);
            assemblyFullName = System.IO.Path.Combine(System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), PRIMAVERA_FOLDER), assemblyName.Name + ".dll");

            if (System.IO.File.Exists(assemblyFullName))
                //return System.Reflection.Assembly.LoadFile(assemblyFullName);
                return System.Reflection.Assembly.LoadFrom(assemblyFullName);
            else
                return null;
        }

        #endregion

        #region Base Overrides

        public override void SetContext(HandlerContext value)
        {
            if (!hasContext)
            {
                dynamic configString = new ConfigString(value.HandlerConfig.ConfigStr);

                if (string.IsNullOrEmpty(configString.TopicId))
                    throw ExceptionHelper.ArgumentNullException("TopicId");

                if (string.IsNullOrEmpty(configString.TaskId))
                    throw ExceptionHelper.ArgumentNullException("TaskId");

                strTopicId = configString.topicId;
                strTaskId = configString.taskId;
            }

            // set context.
            this.Context = value;

            // Set local context flag.
            this.hasContext = true;
        }

        /// <summary>
        /// Processes the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The processed message.</returns>
        public override IMessage ProcessMessage(IMessage message)
        {
            return this.ProcessMessageInternal(message as IntegrationMessage);
        }

        #endregion

        #region Private

        private IMessage ProcessMessageInternal(IntegrationMessage message)
        {
            try
            {
                TopicId = this.strTopicId;
                TaskId = this.strTaskId;

                // Initialize objects using base
                this.Initialize(message);
                
                // Verify if instances have been passed by previous handler
                if (Instances.Count == 0)
                {
                    return new BreakMessage("No instances to process.");
                }

                // Iterate through instances and create messages.
                foreach (Instance instance in this.Instances)
                {
                    TenantId = instance.TenantId;

                    // Pattern to create messages the message objects
                    foreach (Enterprise enterprise in instance.Enterprises)
                    {
                        ExecutePDEX(instance, enterprise.Code);
                    }
                }

                // Return for save handler.
                return BuildIntegrationMessage(BotMessages);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                this.Log(LogEvent.Error(ex));

                throw;
            }
        }

        private void ExecutePDEX(Instance instance, string strEnterpriseCode)
        {
            using (ErpHelper erpHelper = new ErpHelper())
            {
                // Initialize connection to SQL
                erpHelper.SetErpConnectionString(instance, strEnterpriseCode);

                //// Processa as operações assincrona do serviço de integração no inventário
                //erpHelper.Erp.Base.FuncoesGlobais.ProcessaOperacoesAssincronasDoServico("Primavera.Inventory100.ModulesIntegration.dll");
                try
                {
                    //PDEXERP.Main pdexMain = new PDEXERP.Main(erpHelper.Erp, erpHelper.Platform);
                    //pdexMain.DocCabimentacao();
                    erpHelper.Erp.BSO.DSO.ExecuteSQL("UPDATE TDU_PDEXCabimentacao SET CDU_NumCab = 123");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        #endregion Private

        /// <summary>
        /// Adds the actions.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="enterpriseCustomer">The enterprise customer.</param>
        /// <returns>
        /// The actions for this message.
        /// </returns>
        private Collection<BotMessageAction> AddActions(BotMessage b)
        {
            return new Collection<BotMessageAction>()
            {
                // Add Actions - example pkb
                new BotMessageAction()
                {
                    ActionIndex = 0,
                    ActionType = BotMessageActionType.PkbArticle,
                    ActionParameters = "Sample action Parameters. in this case, a PKB article id",
                    Text = "Sample text that should appear on the link"
                }

                // Add more actions as required  
            };
        }

        /// <summary>
        /// Adds the results.
        /// </summary>
        /// <param name="companyMessage">The company message.</param>
        /// <param name="resultsDiff">The results difference.</param>
        private void AddResults(BotMessage companyMessage, DataTable resultsDiff)
        {
            var results = new BotMessageResults();
            results.AddDataTableToResultSet(resultsDiff);

            // for each result we'll add the correspondent action
            foreach (List<Cell> line in results.ResultSets[0])
            {
                // Add action for the first column
                line[1].Action = new BotMessageAction()
                {
                    ActionIndex = 0,
                    ActionType = BotMessageActionType.Drilldown,
                    ActionParameters = "Parameters.",
                    Text = line[1].Value
                };
            }

            // Now we need to define how the table is displayed (view config)
            this.AddViewConfig(results);
            companyMessage.Results = results;
        }

        /// <summary>
        /// Adds the view configuration.
        /// </summary>
        /// <param name="results">The results.</param>
        private void AddViewConfig(BotMessageResults results)
        {
            results.ViewConfig.Add(
                new Entities.Results.TableView()
                {
                    Order = 0,
                    Columns = new System.Collections.ObjectModel.Collection<Entities.Results.Column>()
                    {
                        new Entities.Results.Column()
                        {
                            Name = string.Empty,
                            Visible = false
                        },
                        new Entities.Results.Column()
                        {
                            Name = Entities.Helpers.Functions.GetAllAvailableCulturesForResource(Properties.Resources.ResourceManager, "ResourceName", null),
                            Visible = true
                        },
                    },
                    ResultSet = 0,
                    ShowTitle = true,
                    Title = Entities.Helpers.Functions.GetAllAvailableCulturesForResource(Properties.Resources.ResourceManager, "ResourceName", null)
                });
        }

        #region IDisposable Members (overriden)

        /// <summary>
        /// Called whenever the object instance needs to clean up.
        /// Releases unmanaged and managed resources (optionally).
        /// <c>Dispose(bool disposing)</c> executes in two distinct scenarios:
        /// If disposing equals true, the method has been called directly or indirectly by a user's code.
        /// - Managed and unmanaged resources can be disposed.
        /// If disposing equals false, the method has been called by the runtime from inside the <c>finalizer</c> and you should not reference other objects.
        /// - Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called

            if (!this.Disposed)
            {
                // Dispose managed resources

                if (disposing)
                {
                }

                // Dispose unmanaged resources

                // insert your code here...
            }

            // Dispose on base class

            base.Dispose(disposing);
        }

        #endregion   
    }
}
