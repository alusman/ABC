import React, { FC, useEffect, useState } from "react";
import { AmortizationSchedule, BuyerInfo, BuyerInfoDefaultValues } from "../models";
import { BuyerInfoForm } from "./BuyerInfoForm";
import { Amortization } from "./Amortization";
import axios from 'axios';

const BASE_URL = "http://localhost:59161";

export const Home: FC = () => {
  const [buyerInfoState, setBuyerInfoState] = useState<BuyerInfo>(BuyerInfoDefaultValues);
  const [amortizationScheduleState, setAmortizationScheduleState] = useState<AmortizationSchedule[]>([]);

  useEffect(() => {
    const urlParams = new URLSearchParams(window.location.search);
    const selectedId = urlParams.get('id');
    
    refreshBuyerInfo(selectedId);

    axios.get(`${BASE_URL}/BuyerAmortization/${selectedId}/schedule`)
         .then(res => { setAmortizationScheduleState(res.data); });
  },[]);

  const refreshBuyerInfo = (id: string | null) => {
    if (id) {
      axios.get(`${BASE_URL}/BuyerAmortization/${id}`)
      .then(res => { setBuyerInfoState(res.data as BuyerInfo); });
    }
  }

  const saveHandler = (model: BuyerInfo) => {
      if (model.id === undefined) {
        axios.post(`${BASE_URL}/BuyerAmortization/savebuyerinfo`, {...model})
        .then(res => { setBuyerInfoState(res.data as BuyerInfo); });
      } else {
        axios.put(`${BASE_URL}/BuyerAmortization/updatebuyerinfo`, {...model});
      }
  };

  const buildScheduleHandler = (model: BuyerInfo) => {
    axios.post(`${BASE_URL}/BuyerAmortization/createschedule`, {...model})
    .then(res => {
      setAmortizationScheduleState(res.data);
      
      // needs to include id in the dto in case we get an empty list
      if (model.id === undefined && res.data.length > 0) 
        refreshBuyerInfo(res.data[0].personUnitId ?? null)
    })
  };

  const resetHandler = (reset: boolean) => {
      if (reset) setAmortizationScheduleState([]);
  };

  const deleteHandler = (id: string | null | undefined) => {
    axios.delete(`${BASE_URL}/BuyerAmortization/delete/${id}`)
      .then(() => {
        setBuyerInfoState(BuyerInfoDefaultValues);
        setAmortizationScheduleState([]);
      })
  };

  return (
      <>
          <BuyerInfoForm buyerInfo={buyerInfoState} 
            onSave={saveHandler} 
            onBuildSchedule={buildScheduleHandler} 
            onReset={resetHandler} 
            onDelete={deleteHandler}
          />
          <Amortization amortizations={amortizationScheduleState} />
      </>
  );
};