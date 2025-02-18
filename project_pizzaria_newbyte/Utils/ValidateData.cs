using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace project_pizzaria_newbyte.Utils
{
    class ValidateData
    {
        public bool CP(string cp, bool isJuridical)
        {
            try
            {
                cp = cp.Replace(".", "").Replace("-", "").Replace("/", "");

                if (cp.Any(c => !char.IsDigit(c)))
                {
                    MessageBox.Show("CPF/CNPJ não pode conter letras.");
                    return false;
                }
                else
                {
                    if (isJuridical)
                    {
                        if (cp.Length > 18)
                        {
                            MessageBox.Show("CNPJ inválido.");
                            return false;
                        }
                        else return true;
                    }
                    else
                    {
                        if (cp.Length > 14)
                        {
                            MessageBox.Show("CPF inválido.");
                            return false;
                        }
                        else return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw new NotImplementedException();
            }
        }

        public bool Email(string email)
        {
            try
            {
                if (!email.Contains("@"))
                {
                    MessageBox.Show("Email inválido.");
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw new NotImplementedException();
            }
        }

        public bool Phone(string phone)
        {
            try
            {
                phone = phone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

                if (phone.Any(p => !char.IsDigit(p)))
                {
                    MessageBox.Show("Telefone não pode conter letras.");
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw new NotImplementedException();
            }
        }
    }
}
