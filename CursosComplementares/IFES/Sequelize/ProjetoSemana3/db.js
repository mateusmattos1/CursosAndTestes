const Sequelize = require("sequelize");

// Configuração da instância do Sequelize para Cliente
const sequelizeCliente = new Sequelize({
  dialect: "sqlite",
  storage: "./cliente.sqlite",
});

// Configuração da instância do Sequelize para Fornecedor
const sequelizeFornecedor = new Sequelize({
  dialect: "sqlite",
  storage: "./fornecedor.sqlite",
});

module.exports = { sequelizeCliente, sequelizeFornecedor };
