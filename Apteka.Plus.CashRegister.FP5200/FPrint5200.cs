using log4net;
using System.Collections.Generic;

namespace Apteka.Plus.CashRegister.FP5200
{
    public class FPrint5200 : ICashRegister
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly FprnM1C.IFprnM45 _ecr = new FprnM1C.FprnM45();

        public void PerformXReport()
        {
            try
            {
                Logger.Info("Taking device under control");
                // занимаем порт
                _ecr.DeviceEnabled = true;
                if (_ecr.ResultCode != 0)
                {
                    Logger.Error("Error during taking device under control");
                    return;
                }

                Logger.Info("Getting device status");
                // получаем состояние ККМ
                int status = _ecr.GetStatus();
                if (status != 0)
                {
                    Logger.ErrorFormat("Smth wrong with device. Status {0}", status);
                    return;
                }

                Logger.Info("Checking if there is open reciept");
                // если есть открытый чек, то отменяем его
                if (_ecr.CheckState != 0)
                {
                    Logger.Info("Closing open reciept");
                    if (_ecr.CancelCheck() != 0)
                    {
                        Logger.Error("Error during closing open reciept");
                        return;
                    }
                }

                ////////////////////////////
                // X - отчет
                // устанавливаем пароль администратора ККМ
                _ecr.Password = "29";
                // входим в режим отчетов без гашения
                _ecr.Mode = 2;
                if (_ecr.SetMode() != 0)
                {
                    return;
                }

                // снимаем отчет
                _ecr.ReportType = 2;
                if (_ecr.Report() != 0)
                {
                    return;
                }

                // выходим в режим выбора, чтобы кто-то под введенными паролями не сделал что нибуть нехорошее
                if (_ecr.ResetMode() != 0)
                {
                    return;
                }
            }
            finally
            {
                // освобождаем порт
                _ecr.DeviceEnabled = false;
            }

            if (_ecr.ResultCode != 0)
            {
                Logger.Error("Error during device release");
            }
        }

        public void PerformZReport()
        {
            try
            {
                Logger.Info("Taking device under control");
                // занимаем порт
                _ecr.DeviceEnabled = true;
                if (_ecr.ResultCode != 0)
                {
                    Logger.Error("Error during taking device under control");
                    return;
                }

                Logger.Info("Getting device status");
                // получаем состояние ККМ
                var status = _ecr.GetStatus();
                if (status != 0)
                {
                    Logger.ErrorFormat("Smth wrong with device. Status {0}", status);
                    return;
                }

                Logger.Info("Checking if there is open reciept");
                // если есть открытый чек, то отменяем его
                if (_ecr.CheckState != 0)
                {
                    Logger.Info("Closing open reciept");
                    if (_ecr.CancelCheck() != 0)
                    {
                        Logger.Error("Error during closing open reciept");
                        return;
                    }
                }

                ///////////////////////////
                // Z - отчет
                // устанавливаем пароль системного администратора ККМ
                _ecr.Password = "30";
                // входим в режим отчетов с гашением
                _ecr.Mode = 3;
                if (_ecr.SetMode() != 0)
                {
                    return;
                }

                // снимаем отчет
                _ecr.ReportType = 1;
                if (_ecr.Report() != 0)
                {
                    return;
                }

                // выходим в режим выбора, чтобы кто-то под введенными паролями не сделал что нибуть нехорошее
                if (_ecr.ResetMode() != 0)
                {
                    return;
                }
            }
            finally
            {
                // освобождаем порт
                _ecr.DeviceEnabled = false;
            }

            if (_ecr.ResultCode != 0)
            {
                Logger.Error("Error during device release");
            }
        }

        public void RegisterGoods(IOperator cashOperator, IList<IGood> liGoods, double givenCash)
        {
            try
            {
                Logger.Info("Taking device under control");
                // занимаем порт
                _ecr.DeviceEnabled = true;
                if (_ecr.ResultCode != 0)
                {
                    Logger.Error("Error during taking device unfer control");
                    return;
                }

                Logger.Info("Getting device status");
                // получаем состояние ККМ
                var status = _ecr.GetStatus();
                if (status != 0)
                {
                    Logger.ErrorFormat("Smth wrong with device. Status {0}", status);
                    return;
                }

                Logger.Info("Checking if there is open reciept");
                // если есть открытый чек, то отменяем его
                if (_ecr.CheckState != 0)
                {
                    Logger.Info("Closing open reciept");
                    if (_ecr.CancelCheck() != 0)
                    {
                        Logger.Error("Error during closing open reciept");
                        return;
                    }
                }


                // входим в режим регистрации
                // устанавливаем пароль кассира
                _ecr.Password = cashOperator.Password;
                // входим в режим регистрации
                _ecr.Mode = 1;
                if (_ecr.SetMode() != 0)
                {
                    return;
                }

                foreach (var item in liGoods)
                {
                    // регистрация продажи
                    _ecr.Name = item.Name;
                    _ecr.Price = item.Price;
                    _ecr.Quantity = item.Amount;
                    _ecr.Department = 2;
                    if (_ecr.Registration() != 0)
                    {
                        return;
                    }

                    if (item.Discount != 0)
                    {
                        // скидка суммой на предыдущую позицию
                        _ecr.Percents = item.Discount;
                        _ecr.Destination = 1;
                        if (_ecr.PercentsDiscount() != 0)
                        {
                            return;
                        }
                    }
                }

                // закрытие чека наличными с вводом полученной от клиента суммы
                if (givenCash != 0)
                {
                    _ecr.Summ = givenCash;
                    _ecr.TypeClose = 0;
                    if (_ecr.Delivery() != 0)
                    {
                        return;
                    }
                }
                else
                {
                    // закрытие чека наличными без ввода полученной от клиента суммы
                    _ecr.TypeClose = 0;
                    if (_ecr.CloseCheck() != 0)
                    {
                        return;
                    }
                }
            }
            finally
            {
                // освобождаем порт
                _ecr.DeviceEnabled = false;
            }

            if (_ecr.ResultCode != 0)
            {
                Logger.Error("Error during device release");
            }
        }
    }
}
