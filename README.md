## Requisitos:

1. Visual Studio 2019
2. [.NET Core 6.0]( https://dotnet.microsoft.com/en-us/download/dotnet/6.0) instalado em sua máquina
3. SQL 2019 para importar o banco de dados

## Executando os projetos

1. Clone o repositório: `git clone https://github.com/auth0-blog/unit-integration-test-xunit.git`
2. Vá para a pasta raiz do repositório


## Restauração do Banco

Existe dois arquivos na pasta raiz do projeto
1. bkp_thecat.bkp : backup realizado com os dados importados
2. thecat_script.sql : apenas o script para criação do banco (necessário usar a api de importação no projeto)
3. ficar atento ao usuário de banco de dados que o projeto esta usando alterar.


### Executando o projeto de teste de unidade
1. Após abrir o projeto no visual studio.
2. Va na pasta test e execute os testes unitário e integrados

### Executando os coleção de teste no PostMan
1. Dentro da pasta raiz utilizar o arquivo: TheCat.postman_collection
