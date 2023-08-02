import "./App.css";
import Converter from "./components/Converter/Converter";
import fetchCurrencies from "./api-requests/FetchCurrencies";
import fetchPrice from "./api-requests/FetchPrice";
import useInterval from "./hooks/UseInterval";
import { useEffect, useState } from "react";
import { Currency } from "./types/Currency"
import { CurrencyPrice } from "./types/CurrencyPrice";

function App() {
  const [currencies, setCurrencies] = useState<Currency[]>([]);
  const [currencyPrices, setCurrencyPrices] = useState<Record<string, CurrencyPrice[]>>({});

  const [paymentCurrency, setPaymentCurrency] = useState<string>("");
  const [purchasedCurrency, setPurhcasedCurrency] = useState<string>("");
  const [shouldFetchPrices, setShouldFetchPrices] = useState<boolean>(false);

  const currencyPair = `${paymentCurrency}/${purchasedCurrency}`;

  useEffect(() => {
    fetchCurrencies().then((data) => {
      setCurrencies(data);
      setPaymentCurrency(data[0]["code"]);
      setPurhcasedCurrency(data[1]["code"]);
      setShouldFetchPrices(true);
    });
  }, []);

  useInterval(() => {
    fetchCurrencies().then((data) => setCurrencies(data))
    .then(() => {
      const [paymentCurrency, purchasedCurrency] = currencyPair.split("/");
      const inversedCurrencyPair = `${purchasedCurrency}/${paymentCurrency}`;
      const updatedPrices: Record<string, CurrencyPrice[]> = {};
  
      fetchPrice(paymentCurrency, purchasedCurrency, 5).then((data) => {
        updatedPrices[currencyPair] = data[currencyPair];
        updatedPrices[inversedCurrencyPair] = data[inversedCurrencyPair];
      }).then(() => setCurrencyPrices(updatedPrices));
    });
  }, 10000);

  // Update price only if selected currencies changed
  useEffect(() => {
    if (shouldFetchPrices)
    {
      fetchPrice(paymentCurrency, purchasedCurrency, 5).then((data) => {
        setCurrencyPrices({...currencyPrices, ...data});
      });

      setShouldFetchPrices(false);
    }
  }, [shouldFetchPrices]);

  return (
    <>
      {currencies.length > 0 && currencyPrices[currencyPair] !== undefined && (
      <div className="converters">
        <Converter 
          currencies={currencies}
          paymentCurrency={paymentCurrency}
          purchasedCurrency={purchasedCurrency}
          pricesHistory={currencyPrices[currencyPair]}
        />
      </div>
      )}
    </>
  );
}

export default App;