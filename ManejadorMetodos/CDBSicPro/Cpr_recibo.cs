﻿using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_recibo
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_recibo(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<pr_recibo> ObtenerAnio()
        {
            try
            {
                var sql = _context.pr_recibo.GroupBy(x=>x.anio_recibo).Select(x=>x.FirstOrDefault()).Where(w => w.fecha_entregado !=null).OrderBy(x=>x.anio_recibo).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }

          
        }
        public List<pr_recibo> ObtenerRecibo(string anio)
        {
            try
            {
                var año = Convert.ToInt64(anio);
                var sql = _context.pr_recibo.GroupBy(x => x.anio_recibo).Select(x => x.FirstOrDefault()).Where(w => w.id_perclie == null && w.anio_recibo==año && w.fecha_entregado==null).OrderBy(x => x.id_recibo).ToList();
                return sql;

                
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public bool EntregarRecibo(pr_recibo objRecibo, int anio_recibo,int i , int j)
        {
            try
            {
                var sql = (from com in _context.pr_recibo
                           where com.anio_recibo == anio_recibo && com.id_recibo >=  i && com.id_recibo <= j
                           select com).FirstOrDefault();
                sql.fecha_entregado = objRecibo.fecha_entregado;
                sql.id_perucb = objRecibo.id_perucb;
                sql.id_suc= objRecibo.id_suc;
                _context.SaveChanges();
                return true;

                //string i = this.id_recibo.SelectedValue;
                //string j = this.id_reciboa.SelectedValue;
                //object[] objArray = new object[] { "UPDATE pr_recibo SET fecha_entregado='", Funciones.fc(this.fecha_entregado.Text), "', id_suc='", this.id_suc.SelectedValue, "', id_perucb='", this.id_perucb.SelectedValue, "' WHERE anio_recibo=", anio_recibo, " AND id_recibo>=", i, " and id_recibo <= ", j };
                //string sql = string.Concat(objArray);
                //Acceso db = new Acceso();
                //db.Conectar();
                //db.CrearComando(sql);
                //db.EjecutarComando();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Ejecutar la Transacción", secureException);
            }
        }
        public List<pr_recibo> GenerarRecibo(int anio)
        {
            try
            {

                
                var sql = _context.pr_recibo.Where(w=> w.anio_recibo == anio ).OrderByDescending(x => x.id_recibo ).ToList();
                return sql;

                //string sql = string.Concat("SELECT public.pr_recibo.id_recibo, public.pr_recibo.anio_recibo FROM public.pr_recibo WHERE public.pr_recibo.anio_recibo = ", anio, " ORDER BY public.pr_recibo.id_recibo DESC");
                //Acceso db = new Acceso();
                //db.Conectar();
                //db.CrearComando(sql);
                //DataTable dt = db.Consulta();
                //db.Desconectar();
               
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Consulta", secureException);
            }
        }
        public bool InsertRecibo(int j, string anio)
        {
            try 
            {
                var recibo = new pr_recibo()
                {
                    id_recibo = j,
                    anio_recibo =Convert.ToDecimal(anio)
                };
                //object[] text = new object[] { "INSERT INTO pr_recibo(id_recibo, anio_recibo) VALUES (", j, ",", this.anio.Text, ")" };
                //db.CrearComando(string.Concat(text));
                //db.EjecutarComando();
                _context.pr_recibo.Add(recibo);
                _context.SaveChanges();
                return true;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Consulta", secureException);
            }
        }
    }
}
