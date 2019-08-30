using SistemaLocacaoHBSIS.Enums;
using SistemaLocacaoHBSIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Net;
using System.Net.Mail;

namespace ProjetoTCC.Controllers
{
    public class CustomQuerysController : ApiController
    {
        private ContextDB db = new ContextDB();

        #region CustomQuerysFinalizadas
        [Route("Api/Marcas/{id}/Tipo")]
        [HttpGet]
        public IQueryable<Marca> GetMarcaPorTipo(int id)
        {
            return db.marcas.Where(x => x.TipoVeiculo.Codigo == id);
        }

        [Route("Api/Modelos/{id}/Marca")]
        [HttpGet]
        public IQueryable<Modelo> GetModeloPorMarca(int id)
        {
            return db.modelos.Where(x => x.Marca.Codigo == id);
        }

        [Route("Api/Periodos/{id}/Tipo")]
        [HttpGet]
        public IQueryable<Periodo> GetPeriodosPorMarcaVigentes(int id)
        {
            return db.periodos.Where(x => x.TipoVeiculo.Codigo == id && DateTime.Now <= x.DataFinal);
        }

        [ResponseType(typeof(Locacao))]
        [AcceptVerbs("PATCH")]
        [Route("api/Locacoes/{idStatus}/AtualizarTodos")]
        public IHttpActionResult AprovaTodasLocacao(int idStatus)
        {
            Locacao locacao = db.locacoes.Find(idStatus);
            var listaEmAprovacao = db.locacoes.Where(x => x.Status == StatusLocacao.EM_APROVACAO).ToList();
            var listaVigente = db.locacoes.Where(x => x.Status == StatusLocacao.VIGENTE).ToList();

            foreach (var item in listaEmAprovacao)
            {
                switch (idStatus)
                {
                    case 1:
                        {
                            item.Status = StatusLocacao.VIGENTE;
                            //Enviar(locacao.Colaborador.Email);
                        }
                        break;
                    case 3:
                        {
                            item.Status = StatusLocacao.FILA_DE_ESPERA;
                            //Enviar(locacao.Colaborador.Email);
                        }
                        break;
                }
            };

            db.SaveChanges();

            return Ok("Todos os itens com Status: FILA DE ESPERA foram alterados para VIGENTE.");
        }

        [ResponseType(typeof(Locacao))]
        [AcceptVerbs("PATCH")]
        [Route("api/Locacoes/{codLocacao}/{idStatus}")]
        public IHttpActionResult AprovaLocacao(int codLocacao, int idStatus)
        {
            Locacao locacao = db.locacoes.Find(codLocacao);
            if (locacao == null)
            {
                return NotFound();
            }
            switch (idStatus)
            {
                case 1:
                    {
                        locacao.Status = StatusLocacao.VIGENTE;
                        //Enviar(locacao.Colaborador.Email);
                    }
                    break;
                case 3:
                    locacao.Status = StatusLocacao.FILA_DE_ESPERA; break;
            };

            db.SaveChanges();

            return Ok(locacao);
        }
        static void Enviar(string emailColaborador)
        {
            String FROM = "asrieltiago@outlook.com";
            String FROMNAME = "Asriel";
            String TO = emailColaborador;
            String SMTP_USERNAME = "SEU EMAIL";
            String SMTP_PASSWORD = "SUA SENHA";
            String HOST = "smtp-mail.outlook.com";
            int PORT = 587;
            String SUBJECT = "Status Locacao - HBSIS";
            String BODY = "Informamos que o Status da sua locação alterou para VIGENTE.";

            // Create and build a new MailMessage object
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            message.Subject = SUBJECT;
            message.Body = BODY;

            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                // Pass SMTP credentials
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                // Enable SSL encryption
                client.EnableSsl = true;

                // Try to send the message. Show status in console.
                try
                {
                    client.Send(message);

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        //[ResponseType(typeof(Locacao))]
        //[AcceptVerbs("PATCH")]
        //[Route("api/Locacoes/{idStatus}/{idPeriodo}/AtualizarTodosNoturno")]
        //public IHttpActionResult AprovaTodasLocacao(int idStatus, int idPeriodo)
        //{
        //    Locacao locacao = db.locacoes.Find(idStatus);
        //    Periodo periodo = db.periodos.Find(idPeriodo);
        //
        //    var listaEmAprovacao = db.locacoes.Where(x => x.Status == StatusLocacao.EM_APROVACAO).Where(x => x.Periodo.Id == idPeriodo).ToList();
        //    var vagasVigente = db.locacoes.Where(x => x.Status == StatusLocacao.VIGENTE).Where(x => x.Periodo.Id == idPeriodo).Count();
        //    var vagasDisponiveis = periodo.Vagas;
        //
        //    vagasDisponiveis -= vagasVigente;
        //
        //    if (locacao == null || periodo == null)
        //        return NotFound();
        //
        //    foreach (var item in listaEmAprovacao)
        //    {
        //        switch (idStatus)
        //        {
        //            case 1:
        //                {
        //                    if (vagasDisponiveis == 0)
        //                    {
        //                        item.Status = StatusLocacao.FILA_DE_ESPERA;
        //                        break;
        //                    }
        //
        //                    else
        //                    {
        //                        item.Status = StatusLocacao.VIGENTE;
        //                        vagasDisponiveis--;
        //                        //Enviar(locacao.Colaborador.Email);
        //                    }
        //                }
        //                break;
        //            case 3:
        //                {
        //                    if (vagasDisponiveis > 0)
        //                    {
        //                        item.Status = StatusLocacao.VIGENTE;
        //                        vagasDisponiveis--;
        //                        //Enviar(locacao.Colaborador.Email);
        //                    }
        //                }
        //                break;
        //        }
        //    };
        //
        //    periodo.Vagas = vagasDisponiveis;
        //    db.SaveChanges();
        //
        //    return Ok("Todos os itens com Status: FILA DE ESPERA foram alterados para VIGENTE.");
        //}
        #endregion

        [ResponseType(typeof(Locacao))]
        [AcceptVerbs("PATCH")]
        [Route("api/Locacoes/{idStatus}/{idPeriodo}/{idColaborador}/AtualizarNoturnoId")]
        public IHttpActionResult AprovaLocacaoNoturnoId(int idStatus, int idPeriodo, int idColaborador)
        {
            Locacao locacao = db.locacoes.Find(idColaborador);
            Periodo periodo = db.periodos.Find(idPeriodo);
            Colaborador colaborador = db.colaboradores.Find(idColaborador);
            var noturno = colaborador.TrabalhoNoturno;
            //var listaEmAprovacao = db.locacoes.Where(x => x.Status == StatusLocacao.EM_APROVACAO).Where(x => x.Periodo.Id == idPeriodo).Where(x => x.Colaborador.TrabalhoNoturno == noturno).Where(x => x.Periodo.Noturno == true).ToList();
            var vagasDisponiveis = periodo.Vagas;
            var vagasVigente = db.locacoes.Where(x => x.Status == StatusLocacao.VIGENTE).Where(x => x.Periodo.Id == idPeriodo).Where(x => x.Colaborador.TrabalhoNoturno == noturno).Where(x => x.Periodo.Noturno == true).Count();
                       
            vagasDisponiveis -= vagasVigente;

            if (locacao == null || periodo == null || colaborador == null)
                return NotFound();

            switch (idStatus)
            {
                case 1:
                    {
                        if (vagasDisponiveis == 0)
                        {
                            locacao.Status = StatusLocacao.FILA_DE_ESPERA;
                            break;
                        }

                        else
                        {
                            locacao.Status = StatusLocacao.VIGENTE;
                            vagasDisponiveis--;
                            //Enviar(locacao.Colaborador.Email);
                        }
                    }
                    break;
                case 3:
                    {
                        if (vagasDisponiveis > 0)
                        {
                            locacao.Status = StatusLocacao.VIGENTE;
                            vagasDisponiveis--;
                            //Enviar(locacao.Colaborador.Email);
                        }
                    }
                    break;
            };

            periodo.Vagas = vagasDisponiveis;
            db.SaveChanges();

            return Ok("Todos os itens com Status: FILA DE ESPERA foram alterados para VIGENTE.");
        }

        [ResponseType(typeof(Locacao))]
        [AcceptVerbs("PATCH")]
        [Route("api/Locacoes/{idStatus}/{idPeriodo}/AtualizarTodosNoturno")]
        public IHttpActionResult AprovaTodasLocacaoNoturno(int idStatus, int idPeriodo)
        {
            Locacao locacao = db.locacoes.Find(idStatus);
            Periodo periodo = db.periodos.Find(idPeriodo);
            //Colaborador colaborador = new Colaborador();

            var noturno = locacao.Colaborador.TrabalhoNoturno;
            noturno = true;

            var listaEmAprovacao = db.locacoes
                .Where(x => x.Status == StatusLocacao.EM_APROVACAO)
                .Where(x => x.Periodo.Id == idPeriodo)
                .Where(x => x.Colaborador.TrabalhoNoturno == noturno)
                .Where(x => x.Periodo.Noturno == true).ToList();

            var vagasVigente = db.locacoes
                .Where(x => x.Status == StatusLocacao.VIGENTE)
                .Where(x => x.Periodo.Id == idPeriodo)
                .Where(x => x.Colaborador.TrabalhoNoturno == noturno)
                .Where(x => x.Periodo.Noturno == true).Count();

            var vagasDisponiveis = periodo.Vagas;

            vagasDisponiveis -= vagasVigente;

            if (locacao == null || periodo == null)
                return NotFound();

            foreach (var item in listaEmAprovacao)
            {
                if (noturno == true)
                {
                    switch (idStatus)
                    {
                        case 1:
                            {

                                item.Status = StatusLocacao.VIGENTE;
                                //Enviar(locacao.Colaborador.Email);
                            }
                            break;
                        case 3:
                            {
                                item.Status = StatusLocacao.FILA_DE_ESPERA;
                                //Enviar(locacao.Colaborador.Email);
                            }
                            break;
                    }
                }
            };

            periodo.Vagas = vagasDisponiveis;
            db.SaveChanges();

            return Ok("Todos os itens com Status: FILA DE ESPERA foram alterados para VIGENTE.");
        }
    }
}
