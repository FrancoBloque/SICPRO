﻿using Common;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesClases.ModelSicPro;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_poliza
    {
        #region Constructor Principal
        readonly sicproEntities _context;
        public Cpr_poliza(sicproEntities dbContex)
        {
            _context = dbContex;
        }

        #endregion
        public bool ExistePol(string numpoliza, string no_liquida)
        {
            bool flag=false;
            using (var dbContextTransaccion = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_poliza.Join(_context.pr_polmov, x=>x.id_poliza,s=>s.id_poliza,((x,s)=> new {x.num_poliza, s.no_liquida })).Where(x=>x.num_poliza==numpoliza.ToUpper() && x.no_liquida== no_liquida);
                   if(sql!=null && sql.Count()>0)
                    {
                        flag = true;
                        return flag;
                    }
                    return flag;
                    //string[] strArrays = new string[] { "SELECT pr_poliza.num_poliza, pr_polmov.no_liquida FROM pr_poliza INNER JOIN pr_polmov ON (pr_poliza.id_poliza = pr_polmov.id_poliza) WHERE pr_poliza.num_poliza = upper('", numpoliza, "') AND pr_polmov.no_liquida = upper('", this.no_liquida.Text, "')" };
                    //string sql = string.Concat(strArrays);
                    //Acceso db = new Acceso();
                    //db.Conectar();
                    //db.CrearComando(sql);
                    //DataTable dtgeneral = db.Consulta();
                    //db.Desconectar();
                    //flag = (dtgeneral.Rows.Count <= 0 ? false : true);
                }
                catch (SecureExceptions secureException)
                {
                    throw new SecureExceptions("Error al Generar la Transacción", secureException);
                }
         
            }
        }


    }
}
