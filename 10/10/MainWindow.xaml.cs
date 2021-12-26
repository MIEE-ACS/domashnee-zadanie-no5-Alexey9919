using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pixel[] my_pixel = new Pixel[7];

        public MainWindow()
        {
            InitializeComponent();

            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                my_pixel[i] = new Pixel();

                my_pixel[i].Abscissia = random.Next(-50, 50);
                my_pixel[i].Ordinate = random.Next(-50, 50);
                my_pixel[i].Red = random.Next(0, 255);
                my_pixel[i].Green = random.Next(0, 255);
                my_pixel[i].Blue = random.Next(0, 255);
            }

            RadioButton[] radio_buttons = new RadioButton[7] { radioBtn_1, radioBtn_2, radioBtn_3, radioBtn_4, radioBtn_5, radioBtn_6, radioBtn_7 };

            for (int i = 0; i < 5; i++)
            {
                radio_buttons[i].Content = my_pixel[i].ToString();
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            RadioButton[] radio_buttons = new RadioButton[7] { radioBtn_1, radioBtn_2, radioBtn_3, radioBtn_4, radioBtn_5, radioBtn_6, radioBtn_7 };

            bool flag_add = false;
            bool flag_error = false;

            if (textBo_X.Text == "" || textBo_Y.Text == "" || textBo_R.Text == "" || textBo_G.Text == "" || textBo_B.Text == "")
            {
                MessageBox.Show("!@# Ничего не введено");
            }

            else
            {
                for (int i = 0; i < radio_buttons.Length; i++)
                {
                    if (radio_buttons[i].IsChecked == true)
                    {
                        flag_add = true;

                        if (radio_buttons[i].Content == null)
                        {
                            try
                            {
                                my_pixel[i] = new Pixel();
                                my_pixel[i].Abscissia = int.Parse(textBo_X.Text);
                                my_pixel[i].Ordinate = int.Parse(textBo_Y.Text);
                                my_pixel[i].Red = int.Parse(textBo_R.Text);
                                my_pixel[i].Green = int.Parse(textBo_G.Text);
                                my_pixel[i].Blue = byte.Parse(textBo_B.Text);
                            }

                            catch (Exception error)
                            {
                                MessageBox.Show($"!@# Ошибка ввода данных: {error.Message}");

                                my_pixel[i] = null;
                                flag_error = true;

                                break;
                            }

                            if (flag_add == true && flag_error == false)
                            {
                                radio_buttons[i].Content = my_pixel[i].ToString();
                                break;
                            }

                            else
                            {
                                MessageBox.Show(" Заполните поля снова");
                                break;
                            }
                        }

                        else
                        {
                            MessageBox.Show("!@# Выбранная строчка занята");
                            break;
                        }
                    }
                }

                if (flag_add == false && flag_error == false)
                {
                    MessageBox.Show("!@# Не выбрана строчка ввода");
                }
            }

            textBo_X.Text = string.Empty;
            textBo_Y.Text = string.Empty;
            textBo_R.Text = string.Empty;
            textBo_G.Text = string.Empty;
            textBo_B.Text = string.Empty;
        }

        private void btn_change_Click(object sender, RoutedEventArgs e)
        {
            RadioButton[] radio_buttons = new RadioButton[7] { radioBtn_1, radioBtn_2, radioBtn_3, radioBtn_4, radioBtn_5, radioBtn_6, radioBtn_7 };

            bool flag_add = false;
            bool flag_error = false;

            for (int i = 0; i < radio_buttons.Length; i++)
            {
                if (radio_buttons[i].IsChecked == true && my_pixel[i] != null)
                {
                    if (radio_buttons[i].Content != null)
                    {
                        if (textBo_R.Text != "")
                        {
                            flag_add = true;

                            try
                            {
                                my_pixel[i].Red = int.Parse(textBo_R.Text);
                            }

                            catch (Exception error)
                            {
                                MessageBox.Show($"!@# Ошибка ввода данных: {error.Message}");
                                flag_error = true;
                                break;
                            }
                        }

                        if (textBo_G.Text != "")
                        {
                            flag_add = true;

                            try
                            {
                                my_pixel[i].Green = int.Parse(textBo_G.Text);
                            }

                            catch (Exception error)
                            {
                                MessageBox.Show($"!@# Ошибка ввода данных: {error.Message}");
                                flag_error = true;
                                break;
                            }
                        }

                        if (textBo_B.Text != "")
                        {
                            flag_add = true;

                            try
                            {
                                my_pixel[i].Blue = int.Parse(textBo_B.Text);
                            }

                            catch (Exception error)
                            {
                                MessageBox.Show($"!@# Ошибка ввода данных: {error.Message}");
                                flag_error = true;
                                break;
                            }
                        }
                    }

                    if (flag_add == true)
                    {
                        radio_buttons[i].Content = my_pixel[i].ToString();

                        break;
                    }
                }
            }

            if (flag_error == false && flag_add == false)
            {
                MessageBox.Show("!@# Не выбранo что изменять");
            }

            textBo_X.Text = string.Empty;
            textBo_Y.Text = string.Empty;
            textBo_R.Text = string.Empty;
            textBo_G.Text = string.Empty;
            textBo_B.Text = string.Empty;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            RadioButton[] radio_buttons = new RadioButton[7] { radioBtn_1, radioBtn_2, radioBtn_3, radioBtn_4, radioBtn_5, radioBtn_6, radioBtn_7 };

            bool flag_error = false;

            for (int i = 0; i < radio_buttons.Length; i++)
            {
                if (radio_buttons[i].IsChecked == true)
                {
                    flag_error = true;

                    if (radio_buttons[i].Content != null)
                    {
                        my_pixel[i] = null;
                        radio_buttons[i].Content = null;

                        break;
                    }

                    else
                    {
                        MessageBox.Show("!@# Эта строчка и так пуста");
                        break;
                    }
                }
            }

            if (flag_error == false)
            {
                MessageBox.Show("!@# Не выбрано что удалять");
            }
        }
    }
}
