
--DECLARE
--	@Anio FLOAT = 2017,
--	@Mes FLOAT = 8,
--	@Account FLOAT = 62110001,
--	@TypeConcept NVARCHAR(255) = 'Revenues',
--	@Concept NVARCHAR(255) = 'Labour Costs',
--	@Subconcept NVARCHAR(255) = 'Fixed Blue Collar Labour Cost',
--	@Description NVARCHAR(255) = 'SUELDOS-SALARIOS blue collar';

DECLARE
	@Anio FLOAT = {0},
	@Mes FLOAT = {1},
	@Account FLOAT = {2},
	@TypeConcept NVARCHAR(255) = 'Revenues',
	@Concept NVARCHAR(255) = 'Labour Costs',
	@Subconcept NVARCHAR(255) = 'Fixed Blue Collar Labour Cost',
	@Description NVARCHAR(255) = 'SUELDOS-SALARIOS blue collar';

INSERT	TIPO_CUENTA
	(
		[AÑO],
		[MES],
		[ACCOUNT],
		[TYPE CONCEPT],
		[CONCEPT],
		[SUBCONCEPT],
		[DESCRIPTION]
	)
VALUES
	(
		@Anio,
		@Mes,
		@Account,
		@TypeConcept,
		@Concept,
		@Subconcept,
		@Description
	);
