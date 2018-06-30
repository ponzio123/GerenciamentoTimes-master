using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolModelBiblioteca
{
    /// <summary>
    /// Esta classe utiliza a biblioteca ClosedXML para gerar um arquivo
    /// Excel. Este arquivo será utilizado para criar um relatório gerencial.
    /// </summary>
    public class ServiceClosedXML
    {
        public static void CriarPlanilhaJogadoresTimes(IEnumerable<Time> times, String caminho)
        {
            //Criar um Workbook. Um arquvio excel.
            var workbook = new XLWorkbook();
            foreach (Time t in times)
            {
                //Um arquivo excel pode conter várias planilhas. 
                var worksheet = workbook.Worksheets.Add(t.Nome);               
                worksheet.Cell("A1").Value = "Nome";
                worksheet.Cell("B1").Value = t.Nome;
                worksheet.Cell("A2").Value = "Data de Fundação";
                worksheet.Cell("B2").Value = t.DataFundacao;
                worksheet.Cell("A3").Value = "Jogadores";
                worksheet.Cell("B3").Value = t.Jogadores.Count;
                var columnNome = worksheet.Column("A");
                var columnNumero = worksheet.Column("B");
                var columnDataDeNascimento = worksheet.Column("C");
                columnDataDeNascimento.Width = 12;
                var columnIdade = worksheet.Column("D");
                int ListaJogadoresLinhaInicio = 4;
                columnNome.Cell(ListaJogadoresLinhaInicio).
                    Value = "Nome";
                columnNumero.Cell(ListaJogadoresLinhaInicio).
                    Value = "Número";
                columnDataDeNascimento.Cell(ListaJogadoresLinhaInicio).
                    Value = "Data de Nascimento";
                columnIdade.Cell(ListaJogadoresLinhaInicio).
                    Value = "Idade";
                worksheet.Row(ListaJogadoresLinhaInicio).Style.Fill.BackgroundColor = XLColor.Gray;
                worksheet.Row(ListaJogadoresLinhaInicio).Style.Font.Bold = true;
                ListaJogadoresLinhaInicio++;
                foreach (Jogador j in t.Jogadores)
                {
                    columnNome.Cell(ListaJogadoresLinhaInicio).Value = j.Nome;
                    columnNumero.Cell(ListaJogadoresLinhaInicio).Value = j.Numero;
                    columnDataDeNascimento.Cell(ListaJogadoresLinhaInicio).Value = j.Nascimento;
                    string calcularIdade =
                        "=ARREDMULTB(FRAÇÃOANO(HOJE();C" + ListaJogadoresLinhaInicio + ");1) ";
                    var formula = columnIdade.Cell(ListaJogadoresLinhaInicio);
                    formula.Value = calcularIdade;
                    ListaJogadoresLinhaInicio++;
                }
            }
            //Excel pode utilizar a referência A1 [A1,B2...] ou R1C1
            //Se quiser ler mais sobre acesse o link: https://www.reddit.com/r/excel/comments/6tpgk3/reference_style_r1c1_vs_a1/
            workbook.ReferenceStyle = XLReferenceStyle.A1;
            //Calcular automaticamente os valores das fórmulas.
            workbook.CalculateMode = ClosedXML.Excel.XLCalculateMode.Auto;
            //Persistir o arquivo.
            workbook.SaveAs(caminho,true, evaluateFormulae: true);
        }
    }
}
