CREATE INDEX IDX_1 ON dbo.inforeg_ejecucion_2009  (ANO_EJE);
CREATE INDEX IDX_2 ON dbo.inforeg_ejecucion_2009  (ANO_EJE,SEC_EJEC);
CREATE INDEX IDX_3 ON dbo.inforeg_ejecucion_2009  (ANO_EJE,SEC_EJEC);
CREATE INDEX IDX_4 ON dbo.inforeg_ejecucion_2009  (ANO_EJE,FUNCION);
CREATE INDEX IDX_5 ON dbo.inforeg_ejecucion_2009  (ANO_EJE,FUNCION, PROGRAMA);
CREATE INDEX IDX_6 ON dbo.inforeg_ejecucion_2009  (ANO_EJE,FUNCION, PROGRAMA, SUB_PROGRAMA);
CREATE INDEX IDX_7 ON dbo.inforeg_ejecucion_2009  (ANO_EJE,FUNCION, PROGRAMA, SUB_PROGRAMA, ACT_PROY);
CREATE INDEX IDX_8 ON dbo.inforeg_ejecucion_2009  (ANO_EJE,FUNCION, PROGRAMA, SUB_PROGRAMA, ACT_PROY, COMPONENTE);
CREATE INDEX IDX_9 ON dbo.inforeg_ejecucion_2009  (ANO_EJE,FUNCION, PROGRAMA, SUB_PROGRAMA, ACT_PROY, COMPONENTE, PROGRAMA_PPTO);
CREATE INDEX IDX_10 ON dbo.inforeg_ejecucion_2009  (ANO_EJE,SEC_EJEC, MES_EJEC, FUNCION, 
		PROGRAMA, SUB_PROGRAMA, ACT_PROY, COMPONENTE, PROGRAMA_PPTO,
		FUENTE_FINANC, GENERICA, SUBGENERICA, SUBGENERICA_DET,ESPECIFICA, ESPECIFICA_DET );