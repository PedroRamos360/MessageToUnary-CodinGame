using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution {
    public static string ConverterBinario(string mensagem) {
        string stringBinaria = "";

        foreach (char letra in mensagem) {
            string caracterBinario = "";
            caracterBinario += "0" + Convert.ToString(letra, 2);
            if (caracterBinario.Length == 8) {
                caracterBinario = caracterBinario.Substring(1, 7);
            }
            stringBinaria += caracterBinario;
        }

        return stringBinaria;
    }

    public static string ConverterUnario(string binario, string mensagem) {
        string stringUnaria = "";
        int index = 0;
        int contagem1 = 0;
        int contagem0 = 0;

        foreach (char numero in binario) {
            index += 1;
            if (numero == '1' && contagem0 == 0) {
                contagem1 += 1;
                if (index == binario.Length && contagem1 == 1) {
                    string zeros = new String('0', contagem0);
                    stringUnaria += "0 " + zeros;
                    contagem1 = 0;
                    index = 0;
                }
            }
            if (numero == '0' && contagem1 == 0) {
                contagem0 += 1;
                if (index == binario.Length && contagem0 == 1) {
                    string zeros = new String('0', contagem0);
                    stringUnaria += "00 " + zeros;
                    contagem0 = 0;
                    index = 0;
                }
            }
            if (numero == '1' && contagem0 != 0) {
                contagem1 += 1;
                string zeros = new String('0', contagem0);
                stringUnaria += "00 " + zeros + " ";
                contagem0 = 0;

            }
            if (numero == '0' && contagem1 != 0) {
                contagem0 += 1;
                string zeros = new String('0', contagem1);
                stringUnaria += "0 " + zeros + " ";
                contagem1 = 0;
            }
            if (index == binario.Length && contagem1 != 0) {
                string zeros = new String('0', contagem1);
                stringUnaria += "0 " + zeros;
                contagem1 = 0;
                index = 0;
            }
            if (index == binario.Length && contagem0 != 0) {
                string zeros = new String('0', contagem0);
                stringUnaria += "00 " + zeros;
                contagem0 = 0;
                index = 0;
            }
        }

        return stringUnaria;
    }

    static void Main(string[] args) {
        try {
            string MESSAGE = Console.ReadLine();
            string binario = ConverterBinario(MESSAGE);
            string unario = ConverterUnario(binario, MESSAGE);

            Console.WriteLine(binario);
            Console.WriteLine(unario);
            Console.WriteLine("0 0 00 0000 0 000 00 0000 0 00");
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
        
    }
}