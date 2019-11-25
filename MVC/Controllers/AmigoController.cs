using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers {
    public class AmigoController : Controller {
        private static string base_url = "http://localhost:60494";

        // GET: Amigo
        public async Task<ActionResult> Index() {
            {
                List<AmigoViewModel> profiles = new List<AmigoViewModel>();

                using(var client = new HttpClient()) {
                    client.BaseAddress = new Uri(base_url);
                    var response = await client.GetAsync($"api/amigo");

                    if(response.IsSuccessStatusCode) {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        profiles = JsonConvert.DeserializeObject<List<AmigoViewModel>>(responseContent);
                    }
                }
                return View(profiles);
            }
        }

        public async Task<ActionResult> Details(int id) {
            AmigoViewModel amigoView = new AmigoViewModel();

            using(var cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri(base_url);

                var response = await cliente.GetAsync($"/api/amigo/{id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    amigoView = JsonConvert.DeserializeObject<AmigoViewModel>(responseContent);

                    return View(amigoView);
                }
                return View();
            }
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection) {

            if(ModelState.IsValid) {
                var data = new Dictionary<string, string> {
                    { "Nome", collection["Nome"] },
                    { "Sobrenome", collection["Sobrenome"] },
                    { "Email", collection["Email"] },
                    { "Telefone", collection["Telefone"] },
                    { "Aniversario", collection["Aniversario"] }
                };

                using(var client = new HttpClient()) {
                    client.BaseAddress = new Uri(base_url);

                    using(var requestContent = new FormUrlEncodedContent(data)) {
                        var response = await client.PostAsync("api/amigo", requestContent);

                        if(response.IsSuccessStatusCode) {
                            return RedirectToAction("Index");
                        } else {
                            return View("Error");
                        }
                    }
                }
            }
            return View();
        }

        public ActionResult Edit(int id) {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection) {
            if(ModelState.IsValid) {
                var data = new Dictionary<string, string> {
                    { "Nome", collection["Nome"] },
                    { "Sobrenome", collection["Sobrenome"] },
                    { "Email", collection["Email"] },
                    { "Telefone", collection["Telefone"] },
                    { "Aniversario", collection["Aniversario"] }
                };

                using(var client = new HttpClient()) {
                    client.BaseAddress = new Uri(base_url);

                    using(var requestContent = new FormUrlEncodedContent(data)) {
                        var response = await client.PutAsync($"api/amigo/editar?id={id}", requestContent);

                        if(response.IsSuccessStatusCode) {
                            return RedirectToAction("Index");
                        } else {
                            return View();
                        }
                    }
                }
            }

            return View();
        }

        public ActionResult Delete(int id) {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
