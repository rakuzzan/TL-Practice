import "./Converter.css";
import { Currency } from "../../types/Currency";
import { CurrencyPrice } from "../../types/CurrencyPrice";
import { findCurrencyByCode } from "../../utils/UtilityFunctions.ts";
import Graph from "../Graph/Graph";

type ConverterProps = {
  currencies: Currency[];
  paymentCurrency: string;
  purchasedCurrency: string;
  pricesHistory: CurrencyPrice[];
};

export default function Converter({ currencies, paymentCurrency, purchasedCurrency, pricesHistory }: ConverterProps) {
  return (
    <div className="converter-block">
      <div className="converter">
        <Graph
          currencyPair={`${paymentCurrency}/${purchasedCurrency}`}
          pricesHistory={pricesHistory}
        />
      </div>
      
      <div className="converter-footer">
        <div className="tooltip">More about {paymentCurrency}/{purchasedCurrency}
          <p className="tooltiptext">
            {findCurrencyByCode(currencies, paymentCurrency)!.description}
            {findCurrencyByCode(currencies, purchasedCurrency)!.description}
          </p>
        </div>
      </div>
    </div>
  );
}