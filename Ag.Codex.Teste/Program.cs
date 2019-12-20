using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ag.Codex.Teste
{
    class Program
    {
        static void Main(string[] args)
        {

            var xml = "<xml xmlns=\"https://developers.google.com/blockly/xml\"><block type=\"graph_set_y\" id=\"+!dvEJLNBBnK/ZwFpl$U\" deletable=\"false\" x=\"100\" y=\"100\"><value name=\"VALUE\"><block type=\"math_arithmetic\" id=\"Wm/WLHO8]-n:5$LhMtP@\"><field name=\"OP\">DIVIDE</field><value name=\"A\"><shadow type=\"math_number\" id=\"J$?%aZdXZ#!(/8/iJ1_J\"><field name=\"NUM\">1</field></shadow><block type=\"idee_s0\" id=\"Z6)E?h?~#}PU2:BdqO/n\"/></value><value name=\"B\"><shadow type=\"math_number\" id=\"pr_~o_dzK+;sER*u_dcC\"><field name=\"NUM\">1</field></shadow><block type=\"idee_jornada\" id=\"6bf4?^NqZ|L|w*%Gy*Yo\"/></value></block></value></block></xml>";

            var parser = Ag.Codex.Blocks.Extensions.AddStandardBlocks(new Ag.Codex.Parser());

            parser.AddBlock<Ag.Codex.Blocks.Variables.ConstantSet>("graph_set_y");

            parser.AddBlock<Ag.Codex.Blocks.Variables.ConstantGet>("idee_s0");
            parser.AddBlock<Ag.Codex.Blocks.Variables.ConstantGet>("idee_smin");
            parser.AddBlock<Ag.Codex.Blocks.Variables.ConstantGet>("idee_jornada");

            Context context = new Context();

            context.Variables.Add("idee_s0", Convert.ToDouble("15,5", new CultureInfo("pt-BR")));
            context.Variables.Add("idee_smin", Convert.ToDouble("15,5", new CultureInfo("pt-BR")));
            context.Variables.Add("idee_jornada", Convert.ToDouble("15,5", new CultureInfo("pt-BR")));
            context.Variables.Add("graph_set_y", Convert.ToDouble("0", new CultureInfo("pt-BR")));

            var workplace = parser.Parse(xml);

            workplace.Evaluate(context);

            if (context.Variables.ContainsKey("graph_set_y"))
            {
                Console.WriteLine(context.Variables["graph_set_y"]);
            }

            Console.ReadKey();
        }
    }
}
