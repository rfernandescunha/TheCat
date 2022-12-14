using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCat.Domain.Entities;
using TheCat.Infra.Data;
using TheCat.Infra.Data.Repositories;
using Xunit;

namespace TheCat.Data.Test
{
    public class BreedsTest : BaseTest, IClassFixture<BaseTest.DbTest>
    {
        private ServiceProvider _serviceProvider;

        public BreedsTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Insert de Anúncio")]
        [Trait("Crud", "Anúncio")]
        public async Task E_Possivel_Realizar_Insert_Anuncio()
        {
            using (var context = _serviceProvider.GetService<TheCatContext>())
            {
                var _repository = new BreedsRepository(context);

                var entity = new Breeds
                {
                    //Marca = "MarcaTeste",
                    //Modelo = "ModeloTeste",
                    //Versao = "VersaoTest",
                    //Ano = 2000,
                    //Quilometragem = 20000,
                    //Observacao = "ObservacaoTeste",
                };

                var retornoInsert = await _repository.Insert(entity);

                Assert.NotNull(retornoInsert);
                Assert.False(retornoInsert.id == "abc");
            }
        }


        [Fact(DisplayName = "Update de Anúncio")]
        [Trait("Crud", "Anúncio")]
        public async Task E_Possivel_Realizar_Update_Anuncio()
        {
            using (var context = _serviceProvider.GetService<TheCatContext>())
            {
                var _repository = new BreedsRepository(context);


                var retornoInsert = await _repository.Insert(new Breeds
                {
                    //Marca = "MarcaTeste",
                    //Modelo = "ModeloTeste",
                    //Versao = "VersaoTest",
                    //Ano = 2000,
                    //Quilometragem = 20000,
                    //Observacao = "ObservacaoTeste"
                });


                //retornoInsert.Marca = "MarcaTeste1";
                //retornoInsert.Modelo = "ModeloTeste1";

                var retornoUpdate = await _repository.Update(retornoInsert);

                Assert.NotNull(retornoUpdate);
                //Assert.Equal(retornoInsert.Marca, retornoUpdate.Marca);
                //Assert.Equal(retornoInsert.Modelo, retornoUpdate.Modelo);

            }
        }

        [Fact(DisplayName = "Delete de Anúncio")]
        [Trait("Crud", "Anúncio")]
        public async Task E_Possivel_Realizar_Delete_Anuncio()
        {
            using (var context = _serviceProvider.GetService<TheCatContext>())
            {
                var _repository = new BreedsRepository(context);



                var retornoInsert = await _repository.Insert(new Breeds
                {
                    //Marca = "MarcaTeste",
                    //Modelo = "ModeloTeste",
                    //Versao = "VersaoTest",
                    //Ano = 2000,
                    //Quilometragem = 20000,
                    //Observacao = "ObservacaoTeste"
                });


                var retornoDelete = await _repository.Delete(retornoInsert.id);
                Assert.True(retornoDelete);

            }
        }

        [Fact(DisplayName = "GetBy de Anúncio")]
        [Trait("Crud", "Anúncio")]
        public async Task E_Possivel_Realizar_GetBy_Anuncio()
        {
            using (var context = _serviceProvider.GetService<TheCatContext>())
            {
                var _repository = new BreedsRepository(context);

                var retornoInsert = await _repository.Insert(new Breeds
                {
                    //Marca = "MarcaTeste",
                    //Modelo = "ModeloTeste",
                    //Versao = "VersaoTest",
                    //Ano = 2000,
                    //Quilometragem = 20000,
                    //Observacao = "ObservacaoTeste"
                });


                var retornoFind = await _repository.Find(retornoInsert.id);

                Assert.NotNull(retornoFind);
                Assert.Equal(retornoInsert.id, retornoFind.id);

            }
        }

        [Fact(DisplayName = "GetAll de Anúncio")]
        [Trait("Crud", "Anúncio")]
        public async Task E_Possivel_Realizar_GetAll_Anuncio()
        {
            using (var context = _serviceProvider.GetService<TheCatContext>())
            {
                var _repository = new BreedsRepository(context);

                var retornoInsert1 = await _repository.Insert(new Breeds
                {
                    //Marca = "MarcaTeste",
                    //Modelo = "ModeloTeste",
                    //Versao = "VersaoTest",
                    //Ano = 2000,
                    //Quilometragem = 20000,
                    //Observacao = "ObservacaoTeste"
                });

                var retornoInsert2 = await _repository.Insert(new Breeds
                {
                    //Marca = "MarcaTeste2",
                    //Modelo = "ModeloTeste2",
                    //Versao = "VersaoTest2",
                    //Ano = 2000,
                    //Quilometragem = 20000,
                    //Observacao = "ObservacaoTeste2"
                });


                var retornoFind = await _repository.Find();

                Assert.NotNull(retornoFind);
                Assert.True(retornoFind.Count() > 1);
            }
        }


    }
}
