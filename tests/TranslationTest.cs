using i18n.Extension;
using i18n.Extension.Tests;
using i18n.Extension.Tests.Resources;
using System;
using System.Globalization;
using System.Resources;
using System.Threading;
using Xunit;
using Xunit.Extensions;

namespace i18n.Extension.Tests
{
    public class TranslationTest
    {
        public TranslationTest()
        {
            I18nConfig.SetResources(
                typeof(StringResources), 
                typeof(EnumResources)
            );
        }

        [Theory]
        [InlineData("pt-BR", null, "")]
        [InlineData("es-ES", null, "")]
        [InlineData("en-US", null, "")]
        [InlineData("pt-BR", "", "")]
        [InlineData("es-ES", "", "")]
        [InlineData("en-US", "", "")]
        [InlineData("pt-BR", "Hello", "Olá")]
        [InlineData("es-ES", "Hello", "Hola")]
        [InlineData("en-US", "Hello", "Hello")]
        [InlineData("pt-BR", "Hello World", "Olá Mundo")]
        [InlineData("es-ES", "Hello World", "Hola Mundo")]
        [InlineData("en-US", "Hello World", "Hello World")]
        [InlineData("pt-BR", "Hello_World", "Olá Mundo")]
        [InlineData("es-ES", "Hello_World", "Hola Mundo")]
        [InlineData("en-US", "Hello_World", "Hello World")]
        [InlineData("en-US", Gender.Male, "Male")]
        [InlineData("en-US", Gender.Female, "Female")]
        [InlineData("pt-BR", Gender.Male, "Masculino")]
        [InlineData("pt-BR", Gender.Female, "Feminino")]
        [InlineData("es-ES", Gender.Male, "Masculino")]
        [InlineData("es-ES", Gender.Female, "Femenino")]
        [InlineData("en-US", MathOperation.Add, "Add")]
        [InlineData("en-US", MathOperation.Subtract, "Subtract")]
        [InlineData("en-US", MathOperation.Divide, "Divide")]
        [InlineData("en-US", MathOperation.Multiply, "Multiply")]
        [InlineData("pt-BR", MathOperation.Add, "Adicionar")]
        [InlineData("pt-BR", MathOperation.Subtract, "Subtrair")]
        [InlineData("pt-BR", MathOperation.Divide, "Dividir")]
        [InlineData("pt-BR", MathOperation.Multiply, "Multiplicar")]
        public void TestTranslation(string culture, object value, string expected)
        {
            I18nConfig.LookupFailedStrategy = new IgnoreI18nLookupFailedStrategy();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            Assert.Equal(expected, value.i18n());
        }

        [Theory]
        [InlineData("pt-BR", "HelloWorld")]
        [InlineData("es-ES", "HelloWorld")]
        [InlineData("en-US", "HelloWorld")]
        public void ThrowExceptionWhenKeyNotFound(string culture, string key)
        {
            I18nConfig.LookupFailedStrategy = new ThrowExceptionI18nLookupFailedStrategy();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            Assert.Throws<Exception>(() =>
            {
                key.i18n();
            });
        }

        [Theory]
        [InlineData("pt-BR", "HelloWorld")]
        [InlineData("es-ES", "HelloWorld")]
        [InlineData("en-US", "HelloWorld")]
        public void FormatTextWhenKeyNotFound(string culture, string key)
        {
            I18nConfig.LookupFailedStrategy = new FormatTextI18nLookupFailedStrategy("Key ", " not found");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            Assert.Equal("Key HelloWorld not found", key.i18n());
        }
    }
}
