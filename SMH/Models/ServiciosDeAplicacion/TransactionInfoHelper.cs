using System;
using SMH.Models.Entidades;
using SMH.Models.Requests;

namespace SMH.Models.ServiciosDeAplicacion
{
    public static class TransactionInfoHelper
    {
        public static TransactionInfo CrearTransactionInfo(RequestUserInfo userInfoDTO)
        {
            ValidarArgumentosUserInfo(userInfoDTO);

            return new TransactionInfo(userInfoDTO.UserId, userInfoDTO.ApplicationId,
                                      userInfoDTO.ComputerName, userInfoDTO.Form);
        }

        public static void ValidarArgumentosUserInfo(RequestUserInfo userInfoDTO)
        {
            if (userInfoDTO == null) throw new ArgumentNullException("userInfoDTO");
            // if (string.IsNullOrWhiteSpace(userInfoDTO.FacilityId)) throw new ArgumentException("userInfoDTO.PlantId");
            if (string.IsNullOrWhiteSpace(userInfoDTO.UserId)) throw new ArgumentException("userInfoDTO.UserId");
            if (string.IsNullOrWhiteSpace(userInfoDTO.LanguageId)) throw new ArgumentException("userInfoDTO.LanguageId");
            if (string.IsNullOrWhiteSpace(userInfoDTO.ApplicationId)) throw new ArgumentException("userInfoDTO.ApplicationId");
            // if (string.IsNullOrWhiteSpace(userInfoDTO.ComputerName)) throw new ArgumentException("userInfoDTO.ComputerName");
            // if (string.IsNullOrWhiteSpace(userInfoDTO.Form)) throw new ArgumentException("userInfoDTO.Form");
        }
    }
}