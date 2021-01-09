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
    // TODO: get id from url
    // const id = 'A8289560-E9E0-48EB-9F45-FBD15B643CE7'
    // axios.get(BASE_URL + '/BuyerAmortization/' + id)
    //         .then(res => {
    //             setBuyerInfoState(res.data as BuyerInfo);
    //         })
  },[]);

  const saveHandler = (model: BuyerInfo) => {
      if (model.id === '') {
        axios.post(`${BASE_URL}/BuyerAmortization/savebuyerinfo`, { model })
        .then(res => {
          setBuyerInfoState(res.data);
        })
      } else {
        axios.put(`${BASE_URL}/BuyerAmortization/updatebuyerinfo`, { model })
        .then(res => {
          setBuyerInfoState(res.data);
        })
      }
  };

  const buildScheduleHandler = (model: BuyerInfo) => {
    axios.post(`${BASE_URL}/BuyerAmortization/createschedule`, { model })
    .then(res => {
      setAmortizationScheduleState(res.data);
    })
  };

  const resetHandler = (reset: boolean) => {
      if (reset) setAmortizationScheduleState([]);
  };

  const deleteHandler = (id: string) => {
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