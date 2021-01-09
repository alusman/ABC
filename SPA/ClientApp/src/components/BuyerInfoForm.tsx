import React, {  FC, useState } from "react";
import TextField from '@material-ui/core/TextField';
import { makeStyles } from '@material-ui/core/styles';
import { Button } from "@material-ui/core";
import { BuyerInfo, BuyerInfoDefaultValues } from "../models";

const useStyles = makeStyles((theme) => ({
  root: {
    '& .MuiTextField-root': {
      margin: theme.spacing(1),
      width: '25ch',
    },
  },
  textField: {
    marginLeft: theme.spacing(1),
    marginRight: theme.spacing(1),
    width: 200,
  },
  button: {
    marginLeft: theme.spacing(1),
    marginRight: theme.spacing(1),
  },
  buttonGroup: {
    textAlign: 'center',
  },
}));

export const BuyerInfoForm: 
        FC<{ buyerInfo: BuyerInfo, 
        onSave: (model: BuyerInfo) => void,
        onBuildSchedule: (model: BuyerInfo) => void,
        onReset: (reset: boolean) => void,
        onDelete: (id: string) => void,
    }> = ({ buyerInfo, onSave, onBuildSchedule, onReset, onDelete }) => {

    const classes = useStyles();
    const [state, setState] = useState<BuyerInfo>({...buyerInfo});

    const save = () => onSave(state);
    
    const build = () => onBuildSchedule(state);

    const deleteAll = () => {
        onDelete(state.id);
        reset();
    }

    const reset = () => {
        setState(BuyerInfoDefaultValues); 
        onReset(true);
    }

    const handleChange = (e: React.ChangeEvent<any>) => {
        const key = e.target?.name;
        const value = e.target?.value;
        setState({...state, [key]: value });
    }

    return (
        <form className={classes.root} noValidate autoComplete="off">
            <h3>Buyer's Information</h3>
            <div>
                <TextField disabled value={state.id} id="outlined-read-only-input" label="Buyer ID" InputProps={{ readOnly: true }} variant="outlined" />
                <TextField required name="name" value={state.name} onChange={handleChange} id="outlined-required" label="Buyer Name" variant="outlined" />
                <TextField required name="address" value={state.address} onChange={handleChange} id="outlined-required" label="Address" variant="outlined" />
            </div>
            <hr />
            <h4>Unit Information</h4>
            <div>
                <TextField required name="projectName" value={state.projectName} onChange={handleChange} id="outlined-required" label="Project Name" variant="outlined" />
                <TextField required name="condoUnit" value={state.condoUnit} onChange={handleChange} id="outlined-required" label="Condo Unit" variant="outlined" />
                <TextField required name="loanAmount" value={state.loanAmount} onChange={handleChange} id="outlined-number" label="Loan Amount" type="number" InputLabelProps={{ shrink: true }} variant="outlined" />
                <TextField required name="startOfPayment" value={state.startOfPayment} onChange={handleChange} id="date" label="Payment Start Date" type="date" className={classes.textField} InputLabelProps={{ shrink: true }} />
                <TextField required name="term" value={state.term} onChange={handleChange} id="outlined-number" label="Payment Term" type="number" helperText="No. of Months" InputLabelProps={{ shrink: true }} variant="outlined" />
                <TextField required name="interestRate" value={state.interestRate} onChange={handleChange} id="outlined-number" label="Interest Rate" type="number" InputLabelProps={{ shrink: true }} variant="outlined" />
            </div>
            <div className={classes.buttonGroup}>
                <Button variant="outlined" onClick={reset} className={classes.button}>New</Button>
                <Button variant="outlined" onClick={save} className={classes.button} color="primary">Save</Button>
                <Button variant="outlined" onClick={build} className={classes.button} color="secondary">Build Amortization Schedule</Button>
                <Button variant="contained" onClick={deleteAll} className={classes.button} color="secondary">Delete</Button>
            </div>
        </form>
    );
};