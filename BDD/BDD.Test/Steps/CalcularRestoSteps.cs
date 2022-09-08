using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;
using Xunit;

namespace BDD.Test.Steps
{
    [Binding]
    public class CalcularRestoSteps
    {
        IWebDriver Browser;

        [BeforeScenario]
        public void CreateWebDriver()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService("C:\\Users\\paulo\\OneDrive\\Documentos\\BDD_Labs");

            ChromeOptions chromeOpts = new ChromeOptions();
            chromeOpts.AddArgument("--headless");

            //Cria a instancia do browser antes de executar os cenarios
            Browser = new ChromeDriver(service, chromeOpts);


        }

        [AfterScenario]
        public void CloseWebDriver()
        {
            this.Browser.Close();
            this.Browser.Dispose();
        }

        [Given(@"que naveguei para pagina da calculadora de resto")]
        public void DadoQueNavegueiParaPaginaDaCalculadoraDeResto()
        {
            Browser.Navigate().GoToUrl("https://www.4devs.com.br/resto_da_divisao");
        }

        [Given(@"que o valor inserindo no dividendo é (.*)")]
        public void DadoQueOValorInserindoNoDividendoE(int num)
        {
            var dividendo = Browser.FindElement(By.Id("num1"));
            dividendo.SendKeys(num.ToString());
           
        }

        [Given(@"que o valor inserido no divisor é (.*)")]
        public void DadoQueOValorInseridoNoDivisorE(int num)
        {
            var divisor = Browser.FindElement(By.Id("num2"));
            divisor.SendKeys(num.ToString());
        }

        [When(@"ao um clicar em calcular resto")]
        public void QuandoAoUmClicarEmCalcularResto()
        {
            var botao = Browser.FindElement(By.Id("bt_calcular"));
            botao.Click();
        }

        [Then(@"o resultado do resto é (.*)")]
        public void EntaoOResultadoDoRestoE(int num)
        {
            var resposta = Browser.FindElement(By.Id("texto_resposta")).Text;
            var respostaResto = resposta.Split("\n")[0];
            var resto = respostaResto.Substring(respostaResto.LastIndexOf('=')+1);


            Assert.True(resto == num.ToString());
        }

        [Then(@"o resultado da divisão é (.*)")]
        public void EntaoOResultadoDaDivisaoE(int num)
        {
            var resposta = Browser.FindElement(By.Id("texto_resposta")).Text;
            var respostaTratada = resposta.Split("\n")[1];
            var resultado = respostaTratada.Substring(respostaTratada.LastIndexOf('=') + 1);


            Assert.True(resultado == num.ToString());
        }


    }
}
