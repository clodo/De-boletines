using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extractor.Model.Entity;
using Extractor.Repository;
using Extractor.Repository.Queries;

namespace Visualizador.Controllers
{
    public class AdjudicacionController : Controller
    {
        private readonly IAdjudicacionRepository adjudicationRepository;
        private readonly IBuscadorAdjudicacionesQuery buscadorAdjudicacionesQuery;
        private readonly ITopEntidadesPorPrecioQuery topEntidadesPorPrecioQuery;

        // If you are using Dependency Injection, you can delete the following constructor
        public AdjudicacionController()
            : this(new AdjudicacionRepository(), new BuscadorAdjudicacionesQuery(), new TopEntidadesPorPrecioQuery())
        {
        }

        public AdjudicacionController(IAdjudicacionRepository adjudicationRepository, IBuscadorAdjudicacionesQuery buscadorAdjudicacionesQuery, ITopEntidadesPorPrecioQuery topEntidadesPorPrecioQuery)
        {
            this.adjudicationRepository = adjudicationRepository;
            this.buscadorAdjudicacionesQuery = buscadorAdjudicacionesQuery;
            this.topEntidadesPorPrecioQuery = topEntidadesPorPrecioQuery;
        }

        public ViewResult Index(AdjudicacionFilter filter)
        {
            ViewBag.Filter = filter;
            return View(buscadorAdjudicacionesQuery.GetByFilter(filter));
        }

        public ViewResult Top()
        {
            return View(topEntidadesPorPrecioQuery.GetTop(20));
        }

        public ViewResult Delete()
        {
            adjudicationRepository.DeleteAll();
            return View();
        }

        public JsonResult MeGusta(int id)
        {
            Adjudicacion adjudicacion = adjudicationRepository.Find(id);
            adjudicacion.MeGusta++;
            adjudicationRepository.Save(adjudicacion);
            return Json(new { status = "ok"}, JsonRequestBehavior.AllowGet);
        }


        public JsonResult NoMeGusta(int id)
        {
            Adjudicacion adjudicacion = adjudicationRepository.Find(id);
            adjudicacion.NoMeGusta++;
            adjudicationRepository.Save(adjudicacion);
            return Json(new { status = "ok" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Revisar(int id)
        {
            Adjudicacion adjudicacion = adjudicationRepository.Find(id);
            adjudicacion.Revisar++;
            adjudicationRepository.Save(adjudicacion);
            return Json(new { status = "ok" }, JsonRequestBehavior.AllowGet);
        }

    }
}
