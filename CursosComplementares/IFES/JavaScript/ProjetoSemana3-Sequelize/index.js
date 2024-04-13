// importando as bibliotecas e arquivos
const {
  sequelizeCliente: dbCliente,
  sequelizeFornecedor: dbFornecedor,
} = require("./db");
const Cliente = require("./models/cliente");
const Fornecedor = require("./models/fornecedor");

/// criando o servidor
const express = require("express");
const app = express();
const porta = 9443;
const bodyParser = require("body-parser");

// Setar os valores da view e engine
app.set("view engine", "html");
app.engine("html", require("ejs").renderFile);
app.use(bodyParser.json());
app.use(express.urlencoded({ extended: true }));

// Definindo rotas
app.get("/", (req, res) => {
  res.send("Bem vindo ao cadastro de clientes e fornecedores.");
});

app.get("/cadcliente", function (req, res) {
  res.render("formCliente");
});

app.post("/addcliente", function (req, res) {
  Cliente.create({
    nome: req.body.nome,
    nascimento: req.body.nascimento,
    cidade: req.body.cidade,
    telefone: req.body.telefone,
  }).then(function () {
    res.send("Cliente cadastrado com sucesso!");
  });
});

app.get("/cadfornecedor", function (req, res) {
  res.render("formFornecedor");
});

app.post("/addfornecedor", function (req, res) {
  Fornecedor.create({
    nome: req.body.nome,
    telefone: req.body.telefone,
    email: req.body.email,
  }).then(function () {
    res.send("Fornecedor cadastrado com sucesso!");
  });
});

app.listen(porta, () => {
  console.log("Servidor rodando");
});

(async () => {
  try {
    const resultadoCliente = await dbCliente.sync();
    const resultadoFornecedor = await dbFornecedor.sync();
    console.log(resultadoCliente + resultadoFornecedor);
    const clientes = await Cliente.findAll();
    console.log("Lista de Clientes \n", clientes);
    const fornecedores = await Fornecedor.findAll();
    console.log("Lista de Fornecedores \n", fornecedores);
  } catch (error) {
    console.log(error);
  }
})();
