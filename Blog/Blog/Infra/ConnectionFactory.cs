﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Infra
{
    public class ConnectionFactory
    {
        public static SqlConnection CriarConexaoAberta()
        {
            // Acessar o AppSettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            // recuperar connection string
            IConfiguration configuration = builder.Build();
            string stringConexao = configuration.GetConnectionString("Blog");

            // cria o objeto
            SqlConnection conexao = new SqlConnection(stringConexao);

            // abre a conexão
            conexao.Open();

            return conexao;
        }
    }
}
