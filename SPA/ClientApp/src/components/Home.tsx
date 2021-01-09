import React, { FC, useState } from "react";
import { AmortizationSchedule, BuyerInfo, BuyerInfoDefaultValues } from "../models";
import { BuyerInfoForm } from "./BuyerInfoForm";
import { Amortization } from "./Amortization";

export const Home: FC = () => {
  const [buyerInfoState] = useState<BuyerInfo>(BuyerInfoDefaultValues);
  const [amortizationScheduleState, setAmortizationScheduleState] = useState<AmortizationSchedule[]>([]);

  const saveHandler = (model: BuyerInfo) => {
      console.log(model)
  };

  const buildScheduleHandler = (model: BuyerInfo) => {
      console.log(model)
  };

  const resetHandler = (reset: boolean) => {
      if (reset) setAmortizationScheduleState([]);
  };

  const deleteHandler = (id: string) => {
    console.log(id)
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