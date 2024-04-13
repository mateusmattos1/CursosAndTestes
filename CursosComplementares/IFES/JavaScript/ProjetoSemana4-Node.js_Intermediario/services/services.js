const axios = require("axios");
module.exports = class Services {
  // TAREFAS
  static async TarefaCreate(req, res) {
    let valores = req.body;
    const options = {
      url: "https://7fe0b743-ff1e-477f-95e3-77816bc7b474-00-tlhw1clh2z17.janeway.replit.dev/tarefas/Cadastrar",
      method: "POST",
      data: valores,
    };
    axios(options);
    const mensagem = "Cadastro realizado com sucesso!";
    res.render("mensagem", { mensagem });
  }

  //LISTAR
  static async TarefaListar(req, res) {
    const options = {
      url: "https://7fe0b743-ff1e-477f-95e3-77816bc7b474-00-tlhw1clh2z17.janeway.replit.dev/tarefas",
      method: "GET",
      data: {},
    };
    axios(options).then((response) => {
      console.log(response.data);
      const tarefa = response.data;
      res.render("tarefas/listar", { tarefa });
    });
  }

  //Update
  static async TarefaUpdate(req, res) {
    let valores = req.body;
    const options = {
      url:
        "https://7fe0b743-ff1e-477f-95e3-77816bc7b474-00-tlhw1clh2z17.janeway.replit.dev/tarefas/" +
        valores.id_tarefa,
      method: "PUT",
      data: valores,
    };
    axios(options);
    const mensagem = "Registro atualizado com sucesso";
    res.render("mensagem", { mensagem });
  }

  //Delete
  static async TarefaDelete(req, res) {
    let id_tarefa = req.body.id_tarefa;
    const options = {
      url:
        "https://7fe0b743-ff1e-477f-95e3-77816bc7b474-00-tlhw1clh2z17.janeway.replit.dev/tarefas/" +
        id_tarefa,
      method: "DELETE",
    };
    axios(options);
    const mensagem = "Tarefa excluída com sucesso!";
    res.render("mensagem", { mensagem });
  }

  // USUARIOS 
  // CADASTRAR
  static async UsuarioCreate(req, res) {
    let valores = req.body;
    const options = {
      url: "https://7fe0b743-ff1e-477f-95e3-77816bc7b474-00-tlhw1clh2z17.janeway.replit.dev/usuarios/Cadastrar",
      method: "POST",
      data: valores,
    };
    axios(options);
    const mensagem = "Cadastro realizado com sucesso!";
    res.render("mensagem", { mensagem });
  }

  //LISTAR
  static async UsuarioListar(req, res) {
    const options = {
      url: "https://7fe0b743-ff1e-477f-95e3-77816bc7b474-00-tlhw1clh2z17.janeway.replit.dev/usuarios",
      method: "GET",
      data: {},
    };
    axios(options).then((response) => {
      console.log(response.data);
      const usuario = response.data;
      res.render("usuarios/listar", { usuario });
    });
  }
};
