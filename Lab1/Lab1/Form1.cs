using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            N = alphabetENG_lower.Length;
            vc = new VigenereCipher(alphabetENG_lower, N);           
        }

        char[] alphabetENG_lower = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        //char[] alphabetENG_upper = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public int N;
        VigenereCipher vc;

        string inputText;
        string outputText;
        string keyword;

        string input_path = "input.txt";
        string output_path = "output.txt";
        string output_decode_path = "output_decode_path.txt";
        string key_path = "key.txt";


        private void encrypt_button_Click(object sender, EventArgs e)
        {
            inputText = vc.ReadFile(input_path);
            keyword = vc.ReadFile(key_path);

            vc.WriteFile(vc.Encrypt(inputText, keyword), output_path);
        }

        private void decrypt_button_Click(object sender, EventArgs e)
        {
            outputText = vc.ReadFile(output_path);
            keyword = vc.ReadFile(key_path);


            vc.WriteFile(vc.Decrypt(outputText, keyword), output_decode_path);
        }
    }
}
