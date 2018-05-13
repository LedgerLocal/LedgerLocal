using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LedgerLocal.AdminServer.Service
{
    public class KafkaRunnerThreadService : IKafkaRunnerThreadService
    {
    }
    //    public IGenericMessageService _genericMessageService;

    //    public Task _taskList1;
    //    public Task _taskList2;
    //    public Task _taskList3;
    //    public Task _taskList4;
    //    public Task _taskList5;
    //    public Task _taskList6;

    //    private bool stopped = false;
    //    private Task _runningTask;
    //    private Serilog.ILogger _logger;

    //    public KafkaRunnerThreadService(Serilog.ILogger logger, IGenericMessageService genericMessageService)
    //    {
    //        _genericMessageService = genericMessageService;
    //        stopped = false;
    //        _logger = logger;
    //    }

    //    public void Start()
    //    {
    //        _genericMessageService.StartSubscription();
    //        StartThreadLoop();
    //    }

    //    private void RunT1()
    //    {
    //        _logger.Information("[Azure-MobileServer] Starting PoolMessageForCreditPointBroadcast");
    //        _taskList1 = Task.Run(async () => {

    //            try
    //            {
    //                await _genericMessageService.PoolMessageForTopicStream(TimeSpan.FromDays(1));
    //            }
    //            catch(Exception e)
    //            {
    //                _logger.Error(e, "[Azure-MobileServer] Error PoolMessageForCreditPointBroadcast");
    //            }
                
    //        });
    //    }

    //    private void RunT2()
    //    {
    //        _logger.Information("[Azure-MobileServer] Starting PoolMessageForDebitPointBroadcast");
    //        _taskList2 = Task.Run(async () => {

    //            try
    //            {
    //                await _genericMessageService.PoolMessageForDebitPointBroadcast(TimeSpan.FromDays(1));
    //            }
    //            catch (Exception e)
    //            {
    //                _logger.Error(e, "[Azure-MobileServer] Error PoolMessageForDebitPointBroadcast");
    //            }

                
    //        });
    //    }

    //    private void RunT3()
    //    {
    //        _logger.Information("[Azure-MobileServer] Starting PoolMessageForExchangePointBroadcast");
    //        _taskList3 = Task.Run(async () => {

    //            try
    //            {
    //                await _genericMessageService.PoolMessageForExchangePointBroadcast(TimeSpan.FromDays(1));
    //            }
    //            catch (Exception e)
    //            {
    //                _logger.Error(e, "[Azure-MobileServer] Error PoolMessageForExchangePointBroadcast");
    //            }

    //        });
    //    }

    //    private void RunT4()
    //    {
    //        _logger.Information("[Azure-MobileServer] Starting PoolMessageForVoucherRecalculatedBroadcast");
    //        _taskList4 = Task.Run(async () => {

    //            try
    //            {
    //                await _genericMessageService.PoolMessageForVoucherRecalculatedBroadcast(TimeSpan.FromDays(1));
    //            }
    //            catch (Exception e)
    //            {
    //                _logger.Error(e, "[Azure-MobileServer] Error PoolMessageForVoucherRecalculatedBroadcast");
    //            }
                
    //        });
    //    }

    //    private void RunT5()
    //    {
    //        _logger.Information("[Azure-MobileServer] Starting PoolMessageForRedemptionRequest");
    //        _taskList5 = Task.Run(async () => {

    //            try
    //            {
    //                await _genericMessageService.PoolMessageForRedemptionRequest(TimeSpan.FromDays(1));
    //            }
    //            catch (Exception e)
    //            {
    //                _logger.Error(e, "[Azure-MobileServer] Error PoolMessageForRedemptionRequest");
    //            }

    //        });
    //    }

    //    private void RunT6()
    //    {
    //        _logger.Information("[Azure-MobileServer] Starting PoolMessageShowCoinTerms");
    //        _taskList6 = Task.Run(async () => {

    //            try
    //            {
    //                await _genericMessageService.PoolMessageShowCoinTerms(TimeSpan.FromDays(1));
    //            }
    //            catch (Exception e)
    //            {
    //                _logger.Error(e, "[Azure-MobileServer] Error PoolMessageShowCoinTerms");
    //            }
                
    //        });
    //    }

    //    public void StartThreadLoop()
    //    {
    //        _runningTask = Task.Run(async () =>
    //        {
    //            try
    //            {
    //                RunT1();
    //                RunT2();
    //                RunT3();
    //                RunT4();
    //                RunT5();
    //                RunT6();
    //            }
    //            catch(Exception ex)
    //            {
    //                _logger.Error(ex, "[Azure-MobileServer] Error: StartThreadLoop");
    //            }
                
    //            while (!stopped)
    //            {
    //                try
    //                {
    //                    if (_taskList1.IsCompleted)
    //                    {
    //                        RunT1();
    //                    }

    //                    if (_taskList2.IsCompleted)
    //                    {
    //                        RunT2();
    //                    }

    //                    if (_taskList3.IsCompleted)
    //                    {
    //                        RunT3();
    //                    }

    //                    if (_taskList4.IsCompleted)
    //                    {
    //                        RunT4();
    //                    }

    //                    if (_taskList5.IsCompleted)
    //                    {
    //                        RunT5();
    //                    }

    //                    if (_taskList6.IsCompleted)
    //                    {
    //                        RunT6();
    //                    }

    //                    await Task.Delay(500);
    //                }
    //                catch(Exception e1)
    //                {
    //                    _logger.Error(e1, "[Azure-MobileServer] Error: StartThreadLoop WhenAny");
    //                }
    //            }
    //        });
    //    }

    //    public void Stop()
    //    {
    //        stopped = true;

    //        if (_runningTask != null)
    //        {
    //            _runningTask.Dispose();
    //        }

    //        if (_taskList1 != null)
    //        {
    //            _taskList1.Dispose();
    //        }

    //        if (_taskList2 != null)
    //        {
    //            _taskList2.Dispose();
    //        }

    //        if (_taskList3 != null)
    //        {
    //            _taskList3.Dispose();
    //        }

    //        if (_taskList4 != null)
    //        {
    //            _taskList4.Dispose();
    //        }

    //        if (_taskList5 != null)
    //        {
    //            _taskList5.Dispose();
    //        }

    //        if (_taskList6 != null)
    //        {
    //            _taskList6.Dispose();
    //        }
    //    }
    //}
}