# Developer Evaluation Api

## Configuration
Para configurar o projeto, o primeiro passo é ter um banco de dados Postgres vazio para executar os comandos de atualização do banco utilizando o Entity Framework.
Sendo assim, vá até o arquivo **src > Ambev.DeveloperEvaluation.WebApi > appsettings.json** e crie a variável de ambiente **DefaultConnection** com a string de conexão válida de um banco de dados Postgres.
Por fim, no diretório do projeto **Ambev.DeveloperEvaluation.ORM** execute o comando:
- dotnet ef database update

Após a execução bem sucedida do comando de atualização do banco de dados, deverá ter sido criadas as seguintes entidades/tabelas:
**Sales:** representa a entidade de vendas do sistema, que contém os dados e detalhes da venda, além da lista de relações de produtos desta venda;
**SaleProducts:** representa a relação entre venda e produto, além de abrigar a quantidade vendida de um produto específico na venda;
**Products:** representa a entidade de produto a ser comercializado a partir das vendas;

## Execution and tests
Para executar a aplicação e testá-la, o primeiro passo é adicionar produtos a serem comercializados pelas vendas que serão realizadas no sistema. Para isso basta chamar o seguinte endpoint da aplicação:

POST - /api/Products
BODY {
  "name": "string",
  "unitValue: 0 
}

Após o cadastro bem sucedido dos produtos desejados, já se torna possível realizar uma venda.
Para realizar uma venda, basta chamar o seguinte endpoint e informar os dados corretamente:

POST - /api/Sales
BODY {
  "customer": "string",
  "branch": "string",
  "saleProducts": [
    {
      "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "quantity": 0
    }
  ]
}

Caso seja necessário, use o endpoint **GET - /api/Products/all** para obter todos os dados dos produtos cadastrados na base de dados.
Por fim, é possível testar todos os próximos cenários a partir dos endpoints:

**Atualizar venda**
PUT - /api/Sales
Onde é possível atualizar o cliente e o branch da compra.

**Buscar venda por ID**
GET - /api/Sales/{id}
Onde é possível buscar uma venda a partir do seu ID, passado como parâmetro na rota da requisição.

**Buscar venda por número**
GET - /api/Sales/{number}
Toda venda gera um número único para si e a partir deste número é possível buscar esta venda. Passado como parâmetro na rota da requisição.

**Deletar venda**
DELETE - /api/Sales/{id}
Onde é possível deletar uma venda do banco de dados a partir do seu ID, passado como parâmetro na rota da requisição.

**Cancelar venda**
PATCH - /api/Sales/{id}/cancel
Onde é possível cancelar uma venda completa, passado o ID da venda como parâmetro na rota da requisição.

**Cancelar o item de uma venda**
PATCH - /api/Sales/{id}/cancel/item/{productId}
Onde é possível cancelar apenas um item da venda, recalculando o valor da mesma. É passado o ID da venda e o ID do produto da venda a ser cancelado como parâmetro na rota da requisição.
