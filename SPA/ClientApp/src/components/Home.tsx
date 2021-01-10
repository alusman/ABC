import React, { FC, useEffect, useState } from "react";
import { AmortizationSchedule, BuyerInfo, BuyerInfoDefaultValues } from "../models";
import { BuyerInfoForm } from "./BuyerInfoForm";
import { Amortization } from "./Amortization";
import axios from 'axios';
import { Col, Container, Row } from "react-bootstrap";
import { ListPage } from "./ListPage";

const BASE_URL = "http://localhost:59161";

export const Home: FC = () => {
  const [buyerInfoState, setBuyerInfoState] = useState<BuyerInfo>(BuyerInfoDefaultValues);
  const [amortizationScheduleState, setAmortizationScheduleState] = useState<AmortizationSchedule[]>([]);
  const [buyerList, setBuyerList] = useState<BuyerInfo[]>([]);

  useEffect(() => {
    const urlParams = new URLSearchParams(window.location.search);
    const selectedId = urlParams.get('id');
    
    refreshBuyerList();
    refreshBuyerInfo(selectedId);
    refreshScheduleInfo(selectedId);
  },[]);

  const refreshBuyerList = () => {
      axios.get(`${BASE_URL}/BuyerAmortization/GetBuyerInfoList`)
             .then(res => { setBuyerList(res.data); });
  }

  const refreshBuyerInfo = (id: string | null) => {
    if (id) {
      axios.get(`${BASE_URL}/BuyerAmortization/${id}`)
      .then(res => { setBuyerInfoState(res.data as BuyerInfo); });
    }
  }

  const refreshScheduleInfo = (id: string | null) => {
    if (id) {
      axios.get(`${BASE_URL}/BuyerAmortization/${id}/schedule`)
         .then(res => { setAmortizationScheduleState(res.data); });
    }
  }

  const saveHandler = (model: BuyerInfo) => {
      if (model.id === undefined) {
        axios.post(`${BASE_URL}/BuyerAmortization/savebuyerinfo`, {...model})
        .then(res => { 
          setBuyerInfoState(res.data as BuyerInfo); 
          refreshBuyerList();
        });
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
      {
        refreshBuyerInfo(res.data[0].personUnitId ?? null)
        refreshBuyerList();
      }
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
        refreshBuyerList();
      })
  };

  const selectHandler = (selectedId: string) => {
    refreshBuyerInfo(selectedId);
    refreshScheduleInfo(selectedId);
  };

  return (
      <>
        <Container>
          <Row>
            <Col sm={4}>
              <ListPage buyerList={buyerList} onSelect={selectHandler} />
            </Col>
            <Col sm={8}>
              <BuyerInfoForm buyerInfo={buyerInfoState} 
                onSave={saveHandler} 
                onBuildSchedule={buildScheduleHandler} 
                onReset={resetHandler} 
                onDelete={deleteHandler}
              />
              <Amortization amortizations={amortizationScheduleState} />
            </Col>
          </Row>
      </Container>
      </>
  );
};