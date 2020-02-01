using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution {
    public static string ConverterBinario(string mensagem) {
        string resultado = mensagem;
        string stringBinaria = "";

        foreach (char letra in mensagem) {
            int codigoNum = (int)letra;
            stringBinaria += Convert.ToString(codigoNum, 2);
        }

        resultado = stringBinaria;
        return resultado;
    }

    public static string ConverterUnario(string binario, string mensagem) {
        string stringBinaria = "";
        int index = 0;
        int contagem1 = 0;
        int contagem0 = 0;

        foreach (char numero in binario) { // binario = 1000011
            index += 1;
            if (numero == '1' && contagem0 == 0) {
                contagem1 += 1;
                if (index == (binario.Length / mensagem.Length) && contagem1 == 1) {
                    string zeros = new String('0', contagem0);
                    stringBinaria += "0 " + zeros;
                    contagem1 = 0;
                    index = 0;
                }
            }
            if (numero == '0' && contagem1 == 0) {
                contagem0 += 1;
                if (index == (binario.Length / mensagem.Length) && contagem0 == 1) {
                    string zeros = new String('0', contagem0);
                    stringBinaria += "00 " + zeros;
                    contagem0 = 0;
                    index = 0;
                }
            }
            if (numero == '1' && contagem0 != 0) {
                contagem1 += 1;
                string zeros = new String('0', contagem0);
                stringBinaria += "00 " + zeros + " ";
                contagem0 = 0;

            }
            if (numero == '0' && contagem1 != 0) {
                contagem0 += 1;
                string zeros = new String('0', contagem1);
                stringBinaria += "0 " + zeros + " ";
                contagem1 = 0;
            }
            if (index == (binario.Length / mensagem.Length) && contagem1 != 0) {
                string zeros = new String('0', contagem1);
                stringBinaria += "0 " + zeros;
                contagem1 = 0;
                index = 0;
            }
            if (index == (binario.Length / mensagem.Length) && contagem0 != 0) {
                string zeros = new String('0', contagem0);
                stringBinaria += "00 " + zeros;
                contagem0 = 0;
                index = 0;
            }
        }

        return stringBinaria;
    }

    static void Main(string[] args) {
        string MESSAGE = Console.ReadLine();
        string binario = ConverterBinario(MESSAGE);
        string unario = ConverterUnario(binario, MESSAGE);

        Console.WriteLine(unario);
    }
}