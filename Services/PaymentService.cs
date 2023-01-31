using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TripApplication.Common;
using TripApplication.Data;
using TripApplication.Data.DTO.PaymentDTO;
using TripApplication.Data.DTO.UserDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Services
{
    public class PaymentService
    {
        private MainDb context;
        private IMapper mapper;

        public PaymentService(MainDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Result<PaymentInformation>> CreatePaymentInfo(PaymentInformationDTO payment)
        {
            if (IsCardExist(payment.CardNumber))
            {
                throw new Exception("The card already exist");
            }

            try
            {
                var _payment = mapper.Map<PaymentInformation>(payment);
                context.PaymentInformations.Add(_payment);
                await context.SaveChangesAsync();
                return Result<PaymentInformation>.PrepareSuccess(_payment);

            }catch(Exception ex) { return Result<PaymentInformation>.PrepareFailure(ex.ToString()); }
        }

        public async Task<Result<PaymentInformation>> UpdatePaymentInfo(PaymentInformationDTO payment)
        {
            if (!IsCardExist(payment.CardNumber)) {
                throw new Exception("The card not found!");
            }
            try
            {
                var _payment = mapper.Map<PaymentInformation>(payment);
                context.PaymentInformations.Update(_payment);
                await context.SaveChangesAsync();
                return Result<PaymentInformation>.PrepareSuccess(_payment);

            }catch(Exception ex) { return Result<PaymentInformation>.PrepareFailure(ex.ToString()); }
        }

        public async Task<Result> DeletePaymentInfo(int id)
        {
            if (!IsCradExistById(id)) { throw new Exception("The card not found!"); }

            try
            {
                var _payment = await context.PaymentInformations.FirstOrDefaultAsync(x=>x.Id == id);
                context.PaymentInformations.Remove(_payment);
                await context.SaveChangesAsync();
                return Result.PrepareSuccess();

            }catch(Exception ex) { return Result.PrepareFailure(ex.ToString()); }
        }

        public async Task<Result<List<PaymentInfoDTO>>> GetPaymentInfoById(int id)
        {
            if (!IsCradExistById(id))
            {
                throw new Exception("The card not found!");
            }
            try
            {
                var _payment = await context.PaymentInformations
                    .Select(x => mapper.Map<PaymentInfoDTO>(x)).ToListAsync();
                return Result<List<PaymentInfoDTO>>.PrepareSuccess(_payment);

            }
            catch (Exception ex) { return Result<List<PaymentInfoDTO>>.PrepareFailure(ex.ToString()); }
        }

        public async Task<Result<List<PaymentInfoDTO>>> GetPaymentInfo()
        {
            try
            {
                var _payment = await context.PaymentInformations
                    .Select(x => mapper.Map<PaymentInfoDTO>(x)).ToListAsync();
                return Result<List<PaymentInfoDTO>>.PrepareSuccess(_payment);

            }catch(Exception ex) { return Result<List<PaymentInfoDTO>>.PrepareFailure(ex.ToString()); }
        }

        /////////////////////////////////////////////////////

        private bool IsCardExist(int number)
        {
            return context.PaymentInformations.Any(x =>x.CardNumber== number);
        }

        private bool IsCradExistById(int id)
        {
            return context.PaymentInformations.Any(x => x.Id== id);
        }
    }
}
