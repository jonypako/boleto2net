﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Boleto2Net.Testes
{
    [TestClass]
    public class Banco001_Brasil_17019
    {
        Banco banco;
        Boletos boletos;

        [TestMethod]
        public void Banco001_Brasil_17019_Testes()
        {
            var contaBancaria = new ContaBancaria
            {
                Agencia = "1234",
                DigitoAgencia = "X",
                Conta = "123456",
                DigitoConta = "X",
                Carteira = "17",
                VariacaoCarteira = "019",
                TipoCarteira = TipoCarteira.CarteiraCobrancaSimples,
                TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro,
                TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa
            };
            banco = new Banco(001)
            {
                Cedente = Utils.GerarCedente("1234567", contaBancaria)
            };
            banco.FormataCedente();

            boletos = new Boletos
            {
                Banco = banco
            };

            Banco001_Brasil_17019_DV1();
            Banco001_Brasil_17019_DV2();
            Banco001_Brasil_17019_DV3();
            Banco001_Brasil_17019_DV4();
            Banco001_Brasil_17019_DV5();
            Banco001_Brasil_17019_DV6();
            Banco001_Brasil_17019_DV7();
            Banco001_Brasil_17019_DV8();
            Banco001_Brasil_17019_DV9();

            Utils.TestarArquivoRemessa(TipoArquivo.CNAB240, boletos, nameof(Banco001_Brasil_17019));

            Utils.TestarArquivoRemessa(TipoArquivo.CNAB400, boletos, nameof(Banco001_Brasil_17019));

            Utils.TestarBoletoPDF(boletos, nameof(Banco001_Brasil_17019));

        }

        private void Banco001_Brasil_17019_DV1()
        {
            var boleto = new Boleto
            {
                DataVencimento = new DateTime(2016, 11, 27),
                ValorTitulo = (decimal)400,
                NossoNumero = "5",
                NumeroDocumento = "BO123456E",
                SiglaEspecieDocumento = "DM",
                Banco = banco,
                Sacado = Utils.GerarSacado()
            };
            boleto.Valida();
            Assert.AreEqual("1", boleto.CodigoBarra.DigitoVerificador, "Dígito Verificador diferente de 1");
            Assert.AreEqual("12345670000000005", boleto.NossoNumeroFormatado, "Nosso número inválido");
            Assert.AreEqual("00191699100000400000000001234567000000000517", boleto.CodigoBarra.CodigoDeBarras, "Código de Barra inválido");
            Assert.AreEqual("00190.00009 01234.567004 00000.005173 1 69910000040000", boleto.CodigoBarra.LinhaDigitavel, "Linha digitável inválida");
            boletos.Add(boleto);
        }

        private void Banco001_Brasil_17019_DV2()
        {
            var boleto = new Boleto
            {
                DataVencimento = new DateTime(2016, 11, 27),
                ValorTitulo = (decimal)402,
                NossoNumero = "5",
                NumeroDocumento = "BO123456E",
                SiglaEspecieDocumento = "DM",
                Banco = banco,
                Sacado = Utils.GerarSacado()
            };
            boleto.Valida();
            Assert.AreEqual("2", boleto.CodigoBarra.DigitoVerificador, "Dígito Verificador diferente de 2");
            Assert.AreEqual("12345670000000005", boleto.NossoNumeroFormatado, "Nosso número inválido");
            Assert.AreEqual("00192699100000402000000001234567000000000517", boleto.CodigoBarra.CodigoDeBarras, "Código de Barra inválido");
            Assert.AreEqual("00190.00009 01234.567004 00000.005173 2 69910000040200", boleto.CodigoBarra.LinhaDigitavel, "Linha digitável inválida");
            boletos.Add(boleto);
        }

        private void Banco001_Brasil_17019_DV3()
        {
            var boleto = new Boleto
            {
                DataVencimento = new DateTime(2016, 9, 26),
                ValorTitulo = (decimal)200,
                NossoNumero = "3",
                NumeroDocumento = "BO123456C",
                SiglaEspecieDocumento = "DM",
                Banco = banco,
                Sacado = Utils.GerarSacado()
            };
            boleto.Valida();
            Assert.AreEqual("3", boleto.CodigoBarra.DigitoVerificador, "Dígito Verificador diferente de 3");
            Assert.AreEqual("12345670000000003", boleto.NossoNumeroFormatado, "Nosso número inválido");
            Assert.AreEqual("00193692900000200000000001234567000000000317", boleto.CodigoBarra.CodigoDeBarras, "Código de Barra inválido");
            Assert.AreEqual("00190.00009 01234.567004 00000.003178 3 69290000020000", boleto.CodigoBarra.LinhaDigitavel, "Linha digitável inválida");
            boletos.Add(boleto);
        }

        private void Banco001_Brasil_17019_DV4()
        {
            var boleto = new Boleto
            {
                DataVencimento = new DateTime(2016, 8, 17),
                ValorTitulo = (decimal)1232.78,
                NossoNumero = "1",
                NumeroDocumento = "BO123456A",
                SiglaEspecieDocumento = "DM",
                Banco = banco,
                Sacado = Utils.GerarSacado()
            };
            boleto.Valida();
            Assert.AreEqual("4", boleto.CodigoBarra.DigitoVerificador, "Dígito Verificador diferente de 4");
            Assert.AreEqual("12345670000000001", boleto.NossoNumeroFormatado, "Nosso número inválido");
            Assert.AreEqual("00194688900001232780000001234567000000000117", boleto.CodigoBarra.CodigoDeBarras, "Código de Barra inválido");
            Assert.AreEqual("00190.00009 01234.567004 00000.001172 4 68890000123278", boleto.CodigoBarra.LinhaDigitavel, "Linha digitável inválida");
            boletos.Add(boleto);
        }

        private void Banco001_Brasil_17019_DV5()
        {
            var boleto = new Boleto
            {
                DataVencimento = new DateTime(2017, 3, 19),
                ValorTitulo = (decimal)800,
                NossoNumero = "9",
                NumeroDocumento = "BO123456I",
                SiglaEspecieDocumento = "DM",
                Banco = banco,
                Sacado = Utils.GerarSacado()
            };
            boleto.Valida();
            Assert.AreEqual("5", boleto.CodigoBarra.DigitoVerificador, "Dígito Verificador diferente de 5");
            Assert.AreEqual("12345670000000009", boleto.NossoNumeroFormatado, "Nosso número inválido");
            Assert.AreEqual("00195710300000800000000001234567000000000917", boleto.CodigoBarra.CodigoDeBarras, "Código de Barra inválido");
            Assert.AreEqual("00190.00009 01234.567004 00000.009175 5 71030000080000", boleto.CodigoBarra.LinhaDigitavel, "Linha digitável inválida");
            boletos.Add(boleto);
        }



        private void Banco001_Brasil_17019_DV6()
        {
            var boleto = new Boleto
            {
                DataVencimento = new DateTime(2016, 10, 26),
                ValorTitulo = (decimal)306.52,
                NossoNumero = "4",
                NumeroDocumento = "BO123456D",
                SiglaEspecieDocumento = "DM",
                Banco = banco,
                Sacado = Utils.GerarSacado()
            };
            boleto.Valida();
            Assert.AreEqual("6", boleto.CodigoBarra.DigitoVerificador, "Dígito Verificador diferente de 6");
            Assert.AreEqual("12345670000000004", boleto.NossoNumeroFormatado, "Nosso número inválido");
            Assert.AreEqual("00196695900000306520000001234567000000000417", boleto.CodigoBarra.CodigoDeBarras, "Código de Barra inválido");
            Assert.AreEqual("00190.00009 01234.567004 00000.004176 6 69590000030652", boleto.CodigoBarra.LinhaDigitavel, "Linha digitável inválida");
            boletos.Add(boleto);
        }



        private void Banco001_Brasil_17019_DV7()
        {
            var boleto = new Boleto
            {
                DataVencimento = new DateTime(2016, 10, 26),
                ValorTitulo = (decimal)300,
                NossoNumero = "4",
                NumeroDocumento = "BO123456D",
                SiglaEspecieDocumento = "DM",
                Banco = banco,
                Sacado = Utils.GerarSacado()
            };
            boleto.Valida();
            Assert.AreEqual("7", boleto.CodigoBarra.DigitoVerificador, "Dígito Verificador diferente de 7");
            Assert.AreEqual("12345670000000004", boleto.NossoNumeroFormatado, "Nosso número inválido");
            Assert.AreEqual("00197695900000300000000001234567000000000417", boleto.CodigoBarra.CodigoDeBarras, "Código de Barra inválido");
            Assert.AreEqual("00190.00009 01234.567004 00000.004176 7 69590000030000", boleto.CodigoBarra.LinhaDigitavel, "Linha digitável inválida");
            boletos.Add(boleto);
        }


        private void Banco001_Brasil_17019_DV8()
        {
            var boleto = new Boleto
            {
                DataVencimento = new DateTime(2017, 1, 27),
                ValorTitulo = (decimal)609,
                NossoNumero = "7",
                NumeroDocumento = "BO123456G",
                SiglaEspecieDocumento = "DM",
                Banco = banco,
                Sacado = Utils.GerarSacado()
            };
            boleto.Valida();
            Assert.AreEqual("8", boleto.CodigoBarra.DigitoVerificador, "Dígito Verificador Diferente de 8");
            Assert.AreEqual("12345670000000007", boleto.NossoNumeroFormatado, "Nosso número inválido");
            Assert.AreEqual("00198705200000609000000001234567000000000717", boleto.CodigoBarra.CodigoDeBarras, "Código de Barra inválido");
            Assert.AreEqual("00190.00009 01234.567004 00000.007179 8 70520000060900", boleto.CodigoBarra.LinhaDigitavel, "Linha digitável inválida");
            boletos.Add(boleto);
        }

        private void Banco001_Brasil_17019_DV9()
        {
            var boleto = new Boleto
            {
                DataVencimento = new DateTime(2017, 1, 27),
                ValorTitulo = (decimal)600,
                NossoNumero = "7",
                NumeroDocumento = "BO123456G",
                SiglaEspecieDocumento = "DM",
                Banco = banco,
                Sacado = Utils.GerarSacado()
            };
            boleto.Valida();
            Assert.AreEqual("9", boleto.CodigoBarra.DigitoVerificador, "Dígito Verificador diferente de 9");
            Assert.AreEqual("12345670000000007", boleto.NossoNumeroFormatado, "Nosso número inválido");
            Assert.AreEqual("00199705200000600000000001234567000000000717", boleto.CodigoBarra.CodigoDeBarras, "Código de Barra inválido");
            Assert.AreEqual("00190.00009 01234.567004 00000.007179 9 70520000060000", boleto.CodigoBarra.LinhaDigitavel, "Linha digitável inválida");
            boletos.Add(boleto);
        }

    }
}