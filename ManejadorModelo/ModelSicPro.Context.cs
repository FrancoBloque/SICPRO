﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------
using EntidadesClases.ModelSicPro;
namespace ManejadorModelo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class sicproEntities : DbContext
    {
        public sicproEntities()
            : base("name=sicproEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<co_anticom> co_anticom { get; set; }
        public virtual DbSet<co_porcomi> co_porcomi { get; set; }
        public virtual DbSet<co_presprod> co_presprod { get; set; }
        public virtual DbSet<co_proycartera> co_proycartera { get; set; }
        public virtual DbSet<gr_cierreregistro> gr_cierreregistro { get; set; }
        public virtual DbSet<gr_compania> gr_compania { get; set; }
        public virtual DbSet<gr_componente> gr_componente { get; set; }
        public virtual DbSet<gr_contacto> gr_contacto { get; set; }
        public virtual DbSet<gr_direccion> gr_direccion { get; set; }
        public virtual DbSet<gr_parametro> gr_parametro { get; set; }
        public virtual DbSet<gr_pass> gr_pass { get; set; }
        public virtual DbSet<gr_persona> gr_persona { get; set; }
        public virtual DbSet<gr_tc> gr_tc { get; set; }
        public virtual DbSet<pr_anulada> pr_anulada { get; set; }
        public virtual DbSet<pr_calculo> pr_calculo { get; set; }
        public virtual DbSet<pr_cuotapoliza> pr_cuotapoliza { get; set; }
        public virtual DbSet<pr_devolucion> pr_devolucion { get; set; }
        public virtual DbSet<pr_excluida> pr_excluida { get; set; }
        public virtual DbSet<pr_formriesgo> pr_formriesgo { get; set; }
        public virtual DbSet<pr_grupo> pr_grupo { get; set; }
        public virtual DbSet<pr_liqrec> pr_liqrec { get; set; }
        public virtual DbSet<pr_numaplicas> pr_numaplicas { get; set; }
        public virtual DbSet<pr_pago> pr_pago { get; set; }
        public virtual DbSet<pr_poliza> pr_poliza { get; set; }
        public virtual DbSet<pr_polmov> pr_polmov { get; set; }
        public virtual DbSet<pr_producto> pr_producto { get; set; }
        public virtual DbSet<pr_recibo> pr_recibo { get; set; }
        public virtual DbSet<pr_riesgo> pr_riesgo { get; set; }
        public virtual DbSet<re_caso> re_caso { get; set; }
        public virtual DbSet<re_histcaso> re_histcaso { get; set; }
        public virtual DbSet<re_siniestro> re_siniestro { get; set; }
        public virtual DbSet<co_sueldo> co_sueldo { get; set; }
        public virtual DbSet<gr_acceso> gr_acceso { get; set; }
        public virtual DbSet<pr_pagocompania> pr_pagocompania { get; set; }
        public virtual DbSet<v_gr_cont_dir> v_gr_cont_dir { get; set; }
        public virtual DbSet<v_pr_cias_resum> v_pr_cias_resum { get; set; }
        public virtual DbSet<v_tipopersona> v_tipopersona { get; set; }
        public virtual DbSet<vad_polizaanu> vad_polizaanu { get; set; }
        public virtual DbSet<vcb_anulaciones> vcb_anulaciones { get; set; }
        public virtual DbSet<vcb_cuotaexcludev> vcb_cuotaexcludev { get; set; }
        public virtual DbSet<vcb_cuotaexcludev_obs> vcb_cuotaexcludev_obs { get; set; }
        public virtual DbSet<vcb_cuotasdias> vcb_cuotasdias { get; set; }
        public virtual DbSet<vcb_desglocepago> vcb_desglocepago { get; set; }
        public virtual DbSet<vcb_desglosepago> vcb_desglosepago { get; set; }
        public virtual DbSet<vcb_listacuoamort> vcb_listacuoamort { get; set; }
        public virtual DbSet<vcb_pagoxcuota> vcb_pagoxcuota { get; set; }
        public virtual DbSet<vcb_reciboxanio> vcb_reciboxanio { get; set; }
        public virtual DbSet<vcb_repcob1> vcb_repcob1 { get; set; }
        public virtual DbSet<vcb_repcob2> vcb_repcob2 { get; set; }
        public virtual DbSet<vcb_repcob3> vcb_repcob3 { get; set; }
        public virtual DbSet<vcb_repcob4> vcb_repcob4 { get; set; }
        public virtual DbSet<vcb_repcob5> vcb_repcob5 { get; set; }
        public virtual DbSet<vcb_repcobranzas1> vcb_repcobranzas1 { get; set; }
        public virtual DbSet<vcb_resexcludev> vcb_resexcludev { get; set; }
        public virtual DbSet<vcb_respolpago1> vcb_respolpago1 { get; set; }
        public virtual DbSet<vcb_resumcuotas> vcb_resumcuotas { get; set; }
        public virtual DbSet<vcb_sumdevcuotas> vcb_sumdevcuotas { get; set; }
        public virtual DbSet<vcb_sumexclucuotas> vcb_sumexclucuotas { get; set; }
        public virtual DbSet<vcb_sumexcludev> vcb_sumexcludev { get; set; }
        public virtual DbSet<vcb_telfsclie> vcb_telfsclie { get; set; }
        public virtual DbSet<vcb_totalpago> vcb_totalpago { get; set; }
        public virtual DbSet<vcb_veripoliza1> vcb_veripoliza1 { get; set; }
        public virtual DbSet<vcb_veripoliza2> vcb_veripoliza2 { get; set; }
        public virtual DbSet<vcb_veripoliza3> vcb_veripoliza3 { get; set; }
        public virtual DbSet<vcm_comicap> vcm_comicap { get; set; }
        public virtual DbSet<vcm_comicobrada> vcm_comicobrada { get; set; }
        public virtual DbSet<vcm_comiefect> vcm_comiefect { get; set; }
        public virtual DbSet<vcm_liqcomiejec> vcm_liqcomiejec { get; set; }
        public virtual DbSet<vcm_preascii> vcm_preascii { get; set; }
        public virtual DbSet<vcm_preascii1> vcm_preascii1 { get; set; }
        public virtual DbSet<vcm_prodcap> vcm_prodcap { get; set; }
        public virtual DbSet<vcm_prodtot> vcm_prodtot { get; set; }
        public virtual DbSet<vco_amortizacomis1> vco_amortizacomis1 { get; set; }
        public virtual DbSet<vco_amortizacomis2> vco_amortizacomis2 { get; set; }
        public virtual DbSet<vco_chequeconsaldo> vco_chequeconsaldo { get; set; }
        public virtual DbSet<vco_notacobcia> vco_notacobcia { get; set; }
        public virtual DbSet<vco_veripoliza1> vco_veripoliza1 { get; set; }
        public virtual DbSet<vco_veripoliza2> vco_veripoliza2 { get; set; }
        public virtual DbSet<vco_veripoliza3> vco_veripoliza3 { get; set; }
        public virtual DbSet<vgr_comprol> vgr_comprol { get; set; }
        public virtual DbSet<vgr_spvscias> vgr_spvscias { get; set; }
        public virtual DbSet<vpr_cuotastxt> vpr_cuotastxt { get; set; }
        public virtual DbSet<vpr_excludev> vpr_excludev { get; set; }
        public virtual DbSet<vpr_formriesgo> vpr_formriesgo { get; set; }
        public virtual DbSet<vpr_listasinpago> vpr_listasinpago { get; set; }
        public virtual DbSet<vpr_pagocuota> vpr_pagocuota { get; set; }
        public virtual DbSet<vpr_pergrup> vpr_pergrup { get; set; }
        public virtual DbSet<vpr_polanuvar> vpr_polanuvar { get; set; }
        public virtual DbSet<vpr_polaplivar> vpr_polaplivar { get; set; }
        public virtual DbSet<vpr_polexcluvar> vpr_polexcluvar { get; set; }
        public virtual DbSet<vpr_polexcluvar1> vpr_polexcluvar1 { get; set; }
        public virtual DbSet<vpr_polincluvar> vpr_polincluvar { get; set; }
        public virtual DbSet<vpr_polmaxnr> vpr_polmaxnr { get; set; }
        public virtual DbSet<vpr_polrenovar> vpr_polrenovar { get; set; }
        public virtual DbSet<vre_maxcaso> vre_maxcaso { get; set; }
        public virtual DbSet<vre_memo1> vre_memo1 { get; set; }
        public virtual DbSet<vre_resumpolclie> vre_resumpolclie { get; set; }
        public virtual DbSet<vrp_memo> vrp_memo { get; set; }
        public virtual DbSet<vtemp> vtemp { get; set; }
        public virtual DbSet<zrep> zrep { get; set; }
        public virtual DbSet<zrep_estcta1> zrep_estcta1 { get; set; }
    
        [DbFunction("sicproEntities", "findcheque")]
        public virtual IQueryable<findcheque_Result> findcheque(string cheque, string id_spvs)
        {
            var chequeParameter = cheque != null ?
                new ObjectParameter("cheque", cheque) :
                new ObjectParameter("cheque", typeof(string));
    
            var id_spvsParameter = id_spvs != null ?
                new ObjectParameter("id_spvs", id_spvs) :
                new ObjectParameter("id_spvs", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<findcheque_Result>("[sicproEntities].[findcheque](@cheque, @id_spvs)", chequeParameter, id_spvsParameter);
        }
    
        [DbFunction("sicproEntities", "findcheques")]
        public virtual IQueryable<findcheques_Result> findcheques(string spvs)
        {
            var spvsParameter = spvs != null ?
                new ObjectParameter("spvs", spvs) :
                new ObjectParameter("spvs", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<findcheques_Result>("[sicproEntities].[findcheques](@spvs)", spvsParameter);
        }
    
        [DbFunction("sicproEntities", "findname")]
        public virtual IQueryable<findname_Result> findname(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<findname_Result>("[sicproEntities].[findname](@name)", nameParameter);
        }
    
        [DbFunction("sicproEntities", "pagos_rep")]
        public virtual IQueryable<pagos_rep_Result> pagos_rep(string id_perclie, string id_spvs, string id_cartera, string poliza, string liquida)
        {
            var id_perclieParameter = id_perclie != null ?
                new ObjectParameter("id_perclie", id_perclie) :
                new ObjectParameter("id_perclie", typeof(string));
    
            var id_spvsParameter = id_spvs != null ?
                new ObjectParameter("id_spvs", id_spvs) :
                new ObjectParameter("id_spvs", typeof(string));
    
            var id_carteraParameter = id_cartera != null ?
                new ObjectParameter("id_cartera", id_cartera) :
                new ObjectParameter("id_cartera", typeof(string));
    
            var polizaParameter = poliza != null ?
                new ObjectParameter("poliza", poliza) :
                new ObjectParameter("poliza", typeof(string));
    
            var liquidaParameter = liquida != null ?
                new ObjectParameter("liquida", liquida) :
                new ObjectParameter("liquida", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<pagos_rep_Result>("[sicproEntities].[pagos_rep](@id_perclie, @id_spvs, @id_cartera, @poliza, @liquida)", id_perclieParameter, id_spvsParameter, id_carteraParameter, polizaParameter, liquidaParameter);
        }
    
        [DbFunction("sicproEntities", "pagos_rep1")]
        public virtual IQueryable<pagos_rep1_Result> pagos_rep1(string id_perclie, string id_spvs, string id_cartera, string poliza, string liquida)
        {
            var id_perclieParameter = id_perclie != null ?
                new ObjectParameter("id_perclie", id_perclie) :
                new ObjectParameter("id_perclie", typeof(string));
    
            var id_spvsParameter = id_spvs != null ?
                new ObjectParameter("id_spvs", id_spvs) :
                new ObjectParameter("id_spvs", typeof(string));
    
            var id_carteraParameter = id_cartera != null ?
                new ObjectParameter("id_cartera", id_cartera) :
                new ObjectParameter("id_cartera", typeof(string));
    
            var polizaParameter = poliza != null ?
                new ObjectParameter("poliza", poliza) :
                new ObjectParameter("poliza", typeof(string));
    
            var liquidaParameter = liquida != null ?
                new ObjectParameter("liquida", liquida) :
                new ObjectParameter("liquida", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<pagos_rep1_Result>("[sicproEntities].[pagos_rep1](@id_perclie, @id_spvs, @id_cartera, @poliza, @liquida)", id_perclieParameter, id_spvsParameter, id_carteraParameter, polizaParameter, liquidaParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> pr_calcfrmcred(Nullable<long> idproducto, string idspvs, Nullable<decimal> primatotal, Nullable<bool> tipocuota)
        {
            var idproductoParameter = idproducto.HasValue ?
                new ObjectParameter("idproducto", idproducto) :
                new ObjectParameter("idproducto", typeof(long));
    
            var idspvsParameter = idspvs != null ?
                new ObjectParameter("idspvs", idspvs) :
                new ObjectParameter("idspvs", typeof(string));
    
            var primatotalParameter = primatotal.HasValue ?
                new ObjectParameter("primatotal", primatotal) :
                new ObjectParameter("primatotal", typeof(decimal));
    
            var tipocuotaParameter = tipocuota.HasValue ?
                new ObjectParameter("tipocuota", tipocuota) :
                new ObjectParameter("tipocuota", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("pr_calcfrmcred", idproductoParameter, idspvsParameter, primatotalParameter, tipocuotaParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> pr_calcfrmcred_cuo(Nullable<long> idproducto, string idspvs, Nullable<decimal> primatotal, Nullable<bool> tipocuota, Nullable<int> cuota, Nullable<int> idmovimiento)
        {
            var idproductoParameter = idproducto.HasValue ?
                new ObjectParameter("idproducto", idproducto) :
                new ObjectParameter("idproducto", typeof(long));
    
            var idspvsParameter = idspvs != null ?
                new ObjectParameter("idspvs", idspvs) :
                new ObjectParameter("idspvs", typeof(string));
    
            var primatotalParameter = primatotal.HasValue ?
                new ObjectParameter("primatotal", primatotal) :
                new ObjectParameter("primatotal", typeof(decimal));
    
            var tipocuotaParameter = tipocuota.HasValue ?
                new ObjectParameter("tipocuota", tipocuota) :
                new ObjectParameter("tipocuota", typeof(bool));
    
            var cuotaParameter = cuota.HasValue ?
                new ObjectParameter("cuota", cuota) :
                new ObjectParameter("cuota", typeof(int));
    
            var idmovimientoParameter = idmovimiento.HasValue ?
                new ObjectParameter("idmovimiento", idmovimiento) :
                new ObjectParameter("idmovimiento", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("pr_calcfrmcred_cuo", idproductoParameter, idspvsParameter, primatotalParameter, tipocuotaParameter, cuotaParameter, idmovimientoParameter);
        }
    
        public virtual ObjectResult<GetDataVeriPoliza_Result> GetDataVeriPoliza(Nullable<long> id_poliza, Nullable<long> id_movimiento)
        {
            var id_polizaParameter = id_poliza.HasValue ?
                new ObjectParameter("id_poliza", id_poliza) :
                new ObjectParameter("id_poliza", typeof(long));
    
            var id_movimientoParameter = id_movimiento.HasValue ?
                new ObjectParameter("id_movimiento", id_movimiento) :
                new ObjectParameter("id_movimiento", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDataVeriPoliza_Result>("GetDataVeriPoliza", id_polizaParameter, id_movimientoParameter);
        }
    
        public virtual ObjectResult<GetBisa_Result> GetBisa(string id_spvs, Nullable<long> id_poliza, Nullable<long> id_movimiento)
        {
            var id_spvsParameter = id_spvs != null ?
                new ObjectParameter("id_spvs", id_spvs) :
                new ObjectParameter("id_spvs", typeof(string));
    
            var id_polizaParameter = id_poliza.HasValue ?
                new ObjectParameter("id_poliza", id_poliza) :
                new ObjectParameter("id_poliza", typeof(long));
    
            var id_movimientoParameter = id_movimiento.HasValue ?
                new ObjectParameter("id_movimiento", id_movimiento) :
                new ObjectParameter("id_movimiento", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBisa_Result>("GetBisa", id_spvsParameter, id_polizaParameter, id_movimientoParameter);
        }
    
        public virtual ObjectResult<GetReportMemo_Result> GetReportMemo(Nullable<long> id_poliza, Nullable<long> id_movimiento)
        {
            var id_polizaParameter = id_poliza.HasValue ?
                new ObjectParameter("id_poliza", id_poliza) :
                new ObjectParameter("id_poliza", typeof(long));
    
            var id_movimientoParameter = id_movimiento.HasValue ?
                new ObjectParameter("id_movimiento", id_movimiento) :
                new ObjectParameter("id_movimiento", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetReportMemo_Result>("GetReportMemo", id_polizaParameter, id_movimientoParameter);
        }
    }
}
