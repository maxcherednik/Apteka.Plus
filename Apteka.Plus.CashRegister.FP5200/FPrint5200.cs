using Apteka.Helpers;
using System.Collections.Generic;

namespace Apteka.Plus.CashRegister.FP5200
{
    public class FPrint5200 : ICashRegister
    {
        private readonly static Logger _logger = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private FprnM1C.IFprnM45 ECR = new FprnM1C.FprnM45();

        #region ICashRegister Members

        public void PerformXReport()
        {
            try
            {
                _logger.Info("Taking device under control");
                // занимаем порт
                ECR.DeviceEnabled = true;
                if (ECR.ResultCode != 0)
                {
                    _logger.Error("Error during taking device under control");
                    return;
                }

                _logger.Info("Getting device status");
                // получаем состояние ККМ
                int status = ECR.GetStatus();
                if (status != 0)
                {
                    _logger.ErrorFormat("Smth wrong with device. Status {0}", status);
                    return;
                }

                _logger.Info("Checking if there is open reciept");
                // если есть открытый чек, то отменяем его
                if (ECR.CheckState != 0)
                {
                    _logger.Info("Closing open reciept");
                    if (ECR.CancelCheck() != 0)
                    {
                        _logger.Error("Error during closing open reciept");
                        return;
                    }
                }

                ////////////////////////////
                // X - отчет
                // устанавливаем пароль администратора ККМ
                ECR.Password = "29";
                // входим в режим отчетов без гашения
                ECR.Mode = 2;
                if (ECR.SetMode() != 0)
                {
                    return;
                }

                // снимаем отчет
                ECR.ReportType = 2;
                if (ECR.Report() != 0)
                {
                    return;
                }

                // выходим в режим выбора, чтобы кто-то под введенными паролями не сделал что нибуть нехорошее
                if (ECR.ResetMode() != 0)
                {
                    return;
                }
            }
            finally
            {
                // освобождаем порт
                ECR.DeviceEnabled = false;
            }

            if (ECR.ResultCode != 0)
            {
                _logger.Error("Error during device release");
                return;
            }
        }

        public void PerformZReport()
        {
            try
            {
                _logger.Info("Taking device under control");
                // занимаем порт
                ECR.DeviceEnabled = true;
                if (ECR.ResultCode != 0)
                {
                    _logger.Error("Error during taking device under control");
                    return;
                }

                _logger.Info("Getting device status");
                // получаем состояние ККМ
                int status = ECR.GetStatus();
                if (status != 0)
                {
                    _logger.ErrorFormat("Smth wrong with device. Status {0}", status);
                    return;
                }

                _logger.Info("Checking if there is open reciept");
                // если есть открытый чек, то отменяем его
                if (ECR.CheckState != 0)
                {
                    _logger.Info("Closing open reciept");
                    if (ECR.CancelCheck() != 0)
                    {
                        _logger.Error("Error during closing open reciept");
                        return;
                    }
                }

                ///////////////////////////
                // Z - отчет
                // устанавливаем пароль системного администратора ККМ
                ECR.Password = "30";
                // входим в режим отчетов с гашением
                ECR.Mode = 3;
                if (ECR.SetMode() != 0)
                {
                    return;
                }

                // снимаем отчет
                ECR.ReportType = 1;
                if (ECR.Report() != 0)
                {
                    return;
                }

                // выходим в режим выбора, чтобы кто-то под введенными паролями не сделал что нибуть нехорошее
                if (ECR.ResetMode() != 0)
                {
                    return;
                }
            }
            finally
            {
                // освобождаем порт
                ECR.DeviceEnabled = false;
            }

            if (ECR.ResultCode != 0)
            {
                _logger.Error("Error during device release");
                return;
            }
        }

        public void RegisterGoods(IOperator cashOperator, IList<IGood> liGoods, double givenCash)
        {
            try
            {
                _logger.Info("Taking device under control");
                // занимаем порт
                ECR.DeviceEnabled = true;
                if (ECR.ResultCode != 0)
                {
                    _logger.Error("Error during taking device unfer control");
                    return;
                }

                _logger.Info("Getting device status");
                // получаем состояние ККМ
                int status = ECR.GetStatus();
                if (status != 0)
                {
                    _logger.ErrorFormat("Smth wrong with device. Status {0}", status);
                    return;
                }

                _logger.Info("Checking if there is open reciept");
                // если есть открытый чек, то отменяем его
                if (ECR.CheckState != 0)
                {
                    _logger.Info("Closing open reciept");
                    if (ECR.CancelCheck() != 0)
                    {
                        _logger.Error("Error during closing open reciept");
                        return;
                    }
                }


                // входим в режим регистрации
                // устанавливаем пароль кассира
                ECR.Password = cashOperator.Password;
                // входим в режим регистрации
                ECR.Mode = 1;
                if (ECR.SetMode() != 0)
                {
                    return;
                }

                foreach (var item in liGoods)
                {
                    // регистрация продажи
                    ECR.Name = item.Name;
                    ECR.Price = item.Price;
                    ECR.Quantity = item.Amount;
                    ECR.Department = 2;
                    if (ECR.Registration() != 0)
                    {
                        return;
                    }

                    if (item.Discount != 0)
                    {
                        // скидка суммой на предыдущую позицию
                        ECR.Percents = item.Discount;
                        ECR.Destination = 1;
                        if (ECR.PercentsDiscount() != 0)
                        {
                            return;
                        }
                    }
                }

                // закрытие чека наличными с вводом полученной от клиента суммы
                if (givenCash != 0)
                {
                    ECR.Summ = givenCash;
                    ECR.TypeClose = 0;
                    if (ECR.Delivery() != 0)
                    {
                        return;
                    }
                }
                else
                {
                    // закрытие чека наличными без ввода полученной от клиента суммы
                    ECR.TypeClose = 0;
                    if (ECR.CloseCheck() != 0)
                    {
                        return;
                    }
                }

            }
            finally
            {
                // освобождаем порт
                ECR.DeviceEnabled = false;
            }

            if (ECR.ResultCode != 0)
            {
                _logger.Error("Error during device release");
                return;
            }
        }

        #endregion
    }
}
