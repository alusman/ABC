import React, { FC, useEffect, useState } from "react";
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import { AmortizationSchedule } from "../models";

const useStyles = makeStyles({
    table: {
      minWidth: 650,
    },
    tableContainer: {
      paddingTop: 25
    },
  });

export const Amortization: FC<{ amortizations: AmortizationSchedule[] }> = ({ amortizations }) => {
    const classes = useStyles();
    const [state, setState] = useState<AmortizationSchedule[]>([]);

    useEffect(() => {
        if (amortizations) setState(amortizations);
    },[amortizations]);

    return (
        <div className={classes.tableContainer}>
            <h3>Amortization Schedule</h3>
            <hr />
            <TableContainer component={Paper}>
                <Table className={classes.table} size="small" aria-label="a dense table">
                    <TableHead>
                    <TableRow>
                        <TableCell>Date</TableCell>
                        <TableCell align="right">Principal</TableCell>
                        <TableCell align="right">Interest</TableCell>
                        <TableCell align="right">Total</TableCell>
                        <TableCell align="right">Balance</TableCell>
                        <TableCell align="right">Loan Amount</TableCell>
                        <TableCell align="center">No. of Days</TableCell>
                    </TableRow>
                    </TableHead>
                    <TableBody>
                        {state.map((row) => (
                            <TableRow key={row.id}>
                                <TableCell component="th" scope="row">{row.date}</TableCell>
                                <TableCell align="right">{row.principal.toFixed(2)}</TableCell>
                                <TableCell align="right">{row.interest.toFixed(2)}</TableCell>
                                <TableCell align="right">{row.total.toFixed(2)}</TableCell>
                                <TableCell align="right">{row.balance.toFixed(2)}</TableCell>
                                <TableCell align="right">{row.loanAmount.toFixed(2)}</TableCell>
                                <TableCell align="center">{row.noOfDays.toFixed(0)}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    );
};