using FprnM1C;
using log4net;
using System;
using System.Collections.Generic;

namespace Apteka.Plus.CashRegister.FP5200
{
    public class FPrint5200 : ICashRegister
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IFprnM45 _ecr = new FprnM45();

        public void PerformXReport()
        {
            void performXReportAction()
            {
                // устанавливаем пароль администратора ККМ
                _ecr.Password = "29";
                // входим в режим отчетов без гашения
                _ecr.Mode = 2;
                var statusSetMode = _ecr.SetMode();
                if (statusSetMode != 0)
                {
                    throw new CashRegisterException($"Cant set x report mode. Message: {_ecr.ResultDescription} Error code: {statusSetMode}");
                }

                _ecr.ReportType = 2;
                var statusReport = _ecr.Report();
                if (statusReport != 0)
                {
                    throw new CashRegisterException($"Cant perfom x report. Message: {_ecr.ResultDescription} Error code: {statusSetMode}");
                }

                var statusResetMode = _ecr.ResetMode();
                if (statusResetMode != 0)
                {
                    throw new CashRegisterException($"Cant reset mode after x report. Message: {_ecr.ResultDescription} Error code: {statusSetMode}");
                }
            }

            PerformRegisterAction(performXReportAction);
        }

        public void PerformZReport()
        {
            void performZReportAction()
            {
                // устанавливаем пароль системного администратора ККМ
                _ecr.Password = "30";
                // входим в режим отчетов с гашением
                _ecr.Mode = 3;
                var statusSetMode = _ecr.SetMode();
                if (statusSetMode != 0)
                {
                    throw new CashRegisterException($"Cant set z report mode. Message: {_ecr.ResultDescription} Error code: {statusSetMode}");
                }

                // снимаем отчет
                _ecr.ReportType = 1;
                var statusReport = _ecr.Report();
                if (statusReport != 0)
                {
                    throw new CashRegisterException($"Cant perfom z report. Message: {_ecr.ResultDescription} Error code: {statusSetMode}");
                }

                // выходим в режим выбора, чтобы кто-то под введенными паролями не сделал что нибуть нехорошее
                var statusResetMode = _ecr.ResetMode();
                if (statusResetMode != 0)
                {
                    throw new CashRegisterException($"Cant reset mode after z report. Message: {_ecr.ResultDescription} Error code: {statusSetMode}");
                }
            }

            PerformRegisterAction(performZReportAction);
        }

        public void RegisterGoods(IOperator cashOperator, IList<IGood> liGoods, double givenCash)
        {
            void registerGoodsAction()
            {
                // входим в режим регистрации
                // устанавливаем пароль кассира
                _ecr.Password = cashOperator.Password;
                // входим в режим регистрации
                _ecr.Mode = 1;
                var statusSetMode = _ecr.SetMode();
                if (statusSetMode != 0)
                {
                    throw new CashRegisterException($"Cant set mode 1. Message: {_ecr.ResultDescription} Error code: {statusSetMode}");
                }

                foreach (var item in liGoods)
                {
                    // регистрация продажи
                    _ecr.Name = item.Name;
                    _ecr.Price = item.Price;
                    _ecr.Quantity = item.Amount;
                    _ecr.Department = 2;
                    var statusRegistration = _ecr.Registration();
                    if (statusRegistration != 0)
                    {
                        throw new CashRegisterException($"Cant make registration. Message: {_ecr.ResultDescription} Error code: {statusRegistration}");
                    }
                }

                // закрытие чека наличными с вводом полученной от клиента суммы
                if (givenCash != 0)
                {
                    _ecr.Summ = givenCash;
                    _ecr.TypeClose = 0;
                    var deliveryStatus = _ecr.Delivery();
                    if (deliveryStatus != 0)
                    {
                        throw new CashRegisterException($"Cant finish receipt with money. " +
                            $"Message: {_ecr.ResultDescription} " +
                            $"Error code: {deliveryStatus}");
                    }
                }
                else
                {
                    // закрытие чека наличными без ввода полученной от клиента суммы
                    _ecr.TypeClose = 0;
                    var closingCheckStatus = _ecr.CloseCheck();
                    if (closingCheckStatus != 0)
                    {
                        throw new CashRegisterException($"Cant finish receipt without money. Message: {_ecr.ResultDescription} Error code: {closingCheckStatus}");
                    }
                }
            }

            PerformRegisterAction(registerGoodsAction);
        }

        private void PerformRegisterAction(Action registerAction)
        {
            try
            {
                Logger.Info("Taking device under control");
                _ecr.DeviceEnabled = true;
                var statusUnderControl = _ecr.ResultCode;
                if (statusUnderControl != 0)
                {
                    throw new CashRegisterException($"Error during taking device under control. Message: {_ecr.ResultDescription} Error code: {statusUnderControl}");
                }

                Logger.Info("Getting device status");
                var status = _ecr.GetStatus();
                if (status != 0)
                {
                    throw new CashRegisterException($"Cant get device status. Message: {_ecr.ResultDescription} Error code: {status}");
                }

                Logger.Info("Checking if there is open reciept");
                // если есть открытый чек, то отменяем его
                if (_ecr.CheckState != 0)
                {
                    Logger.Info("Closing open reciept");
                    var statusCancelCheck = _ecr.CancelCheck();
                    if (statusCancelCheck != 0)
                    {
                        throw new CashRegisterException($"Cant close open receipt. Message: {_ecr.ResultDescription} Error code: {statusCancelCheck}");
                    }
                }

                /////////// action here ////////////////

                registerAction();
            }
            finally
            {
                _ecr.DeviceEnabled = false;
            }

            var releaseCode = _ecr.ResultCode;
            if (releaseCode != 0)
            {
                throw new CashRegisterException($"Error during device release. Message: {_ecr.ResultDescription} Error code: {releaseCode}");
            }
        }
    }
}
