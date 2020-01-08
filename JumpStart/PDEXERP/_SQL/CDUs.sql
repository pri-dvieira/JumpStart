/* DocumentosCompra */

-- Delets and drops
DELETE FROM StdCamposVar WHERE Tabela = 'DocumentosCompra' AND Campo IN ('CDU_SujeitoCabimentacao')
GO
EXEC STD_DropColumn [DocumentosCompra], [CDU_SujeitoCabimentacao]
GO

-- Creates and inserts
ALTER TABLE DocumentosCompra ADD [CDU_SujeitoCabimentacao] [bit] NULL
GO
INSERT INTO StdCamposVar (Tabela, Campo, Descricao, Texto, Visivel, Ordem, Query, ExportarTTE, DadosSensiveis) values ('DocumentosCompra', 'CDU_SujeitoCabimentacao', 'Sujeito a Cabimentação', 'Cabimentação:', 1, 1, null, 0, 0)
GO
