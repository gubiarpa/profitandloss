using Apm.ProfitAndLoss.Datatier.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apm.ProfitAndLoss.Datatier.Types;
using Apm.ProfitAndLoss.Datatier.Domain;
using System.Data;

namespace Apm.ProfitAndLoss.Datatier.Contract.Repository
{
    public class BdCuentaContableRepository : SQLBase
    {
        public BdCuentaContableRepository() : base(OriginType.APM)
        {
        }

        public void Create(CuentaContable cuentaContable)
            // int Año, int Mes, string Account, string TypConcept, string Concept, string Subconcept, string Description)
        {
            AddInParameter("@Anio", cuentaContable.Year);
            AddInParameter("@Mes", cuentaContable.Month);
            AddInParameter("@Account", cuentaContable.Account);
            AddInParameter("@TypeConcept", cuentaContable.TypeConcept);
            AddInParameter("@Concept", cuentaContable.Concept);
            AddInParameter("@Subconcept", cuentaContable.Subconcept);
            AddInParameter("@Description", cuentaContable.Description);            
            ExecuteSPWithoutResults("USP_CreateCuentaContable");
        }

        public List<CuentaContable> Read(int año, int mes, string account = null)
        {
            try
            {
                AddInParameter("@Anio", año);
                AddInParameter("@Mes", mes);
                if (account != null) AddInParameter("@Account", account);
                var result = ExecuteSPWithResults("USP_ReadCuentasContables");

                List<CuentaContable> cuentaContableList = new List<CuentaContable>();

                foreach (DataRow row in result.Rows)
                {
                    cuentaContableList.Add(new CuentaContable()
                    {
                        Account = row["Account"].ToString(),
                        Year = int.Parse(año.ToString()),
                        Month = int.Parse(mes.ToString()),
                        TypeConcept = row["Type Concept"].ToString(),
                        Concept = row["Concept"].ToString(),
                        Subconcept = row["Subconcept"].ToString(),
                        Description = row["Description"].ToString()
                    });
                }

                return cuentaContableList;
            }
            catch
            {
                return null;
            }
        }

        public void Replicate(int añoOrigen, int mesOrigen, int añoDestino, int mesDestino)
        {
            try
            {
                AddInParameter("@AnioOrigen", añoOrigen);
                AddInParameter("@MesOrigen", mesOrigen);
                AddInParameter("@AnioDestino", añoDestino);
                AddInParameter("@MesDestino", mesDestino);
                ExecuteSPWithoutResults("USP_ReplicaCuentas");
            }
            catch
            {
            }
        }
    }
}