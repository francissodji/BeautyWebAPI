using BeautyWebAPI.Data.Context;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.Data.Repositories;
using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.ModelsHelper
{
    public class FindBraidingCost
    {
        private readonly IBeautyBaseRepository _beautyBaseRepos;

        public FindBraidingCost(IBeautyBaseRepository beautyBaseRepos)
        {
            _beautyBaseRepos = beautyBaseRepos;
        }

        public double GetBraidingCost(int IdStyle, int IdSize, int IdExtrat, char typeService, bool tackDown, string returnType)
        {
            double thereturnCost = 0;
            Style theRelatedStyle = new Style();
            ExtratStyle theRelatedExtratStyle = new ExtratStyle();
            BraidingCost braidingCost = new BraidingCost();

            double totalCost = 0;
            double totalTouchUpCost = 0;
            double totalExtraSizeLengthCost = 0;

            try
            {
                theRelatedStyle = _beautyBaseRepos.StyleRepository.GetStyleById(IdStyle);


                var priceInExtratStyle = _beautyBaseRepos.ExtratStyleRepository.GetAllExtratPrices(IdStyle, IdSize, IdExtrat);

                double ESCostExtra = 0;
                double ESCostTouchUpExtra = 0;
                double ESCostExtraSize = 0;
                double ESCostBusyExtra = 0;
                double ESCostHairDeductExtra = 0;

                if (theRelatedStyle != null && theRelatedExtratStyle != null)
                {
                    foreach (var abraidingPrice in priceInExtratStyle) // There should be only one line in 
                    {
                        ESCostExtra = abraidingPrice.CostExtra;
                        ESCostTouchUpExtra = abraidingPrice.CostExtra;
                        ESCostExtraSize = abraidingPrice.CostExtraSize;
                        ESCostBusyExtra = abraidingPrice.CostBusyExtra;
                        ESCostHairDeductExtra = abraidingPrice.CostHairDeductExtra;
                    }
                    //Calculate Total Cost

                    switch (typeService)
                    {
                        case 'F': // Full Service
                            totalExtraSizeLengthCost = ESCostExtra + ESCostExtraSize + ESCostBusyExtra;
                            totalCost += (double)theRelatedStyle.CostStyle;
                            totalCost += totalExtraSizeLengthCost; ;
                            totalCost -= ESCostHairDeductExtra; // Only when the hair is provided

                            if (tackDown)
                                totalCost += (double)theRelatedStyle.PriceTakeOffHair;

                            break;

                        case 'T': //Touch UP
                            totalTouchUpCost = (double)theRelatedStyle.CostTouchUp + ESCostTouchUpExtra;
                            totalCost = totalTouchUpCost;

                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            switch (returnType)
            {
                case "TOTALCOST": //Touch UP
                    thereturnCost = totalCost;
                    break;

            }

            return thereturnCost;
        }

    }
}
