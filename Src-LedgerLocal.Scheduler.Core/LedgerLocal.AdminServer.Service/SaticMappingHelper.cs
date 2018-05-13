using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service
{
    public class SaticMappingHelper
    {
        public static string GetAssetCmc(string asset)
        {
            var symbolOnCmc = asset;

            if (symbolOnCmc == "BCC")
            {
                symbolOnCmc = "BCH";
            }

            if (symbolOnCmc == "IOTA")
            {
                symbolOnCmc = "MIOTA";
            }

            return symbolOnCmc;
        }

        public static string FromAssetCmcToBinance(string asset)
        {
            var symbolOnCmc = asset;

            if (symbolOnCmc == "BCH")
            {
                symbolOnCmc = "BCC";
            }

            if (symbolOnCmc == "MIOTA")
            {
                symbolOnCmc = "IOTA";
            }

            return symbolOnCmc;
        }
    }
}
