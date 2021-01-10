import React, { FC, useEffect, useState } from "react";
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import { BuyerInfo } from "../models";

const useStyles = makeStyles({
  table: {
    minWidth: 250,
  },
  columnHeader: {
      fontWeight: "bold"
  }
});

export const ListPage: 
    FC<{ buyerList: BuyerInfo[]
         onSelect: (id: string) => void,
    }> = ({ buyerList, onSelect }) => {
    const classes = useStyles();
    const [state, setState] = useState<BuyerInfo[]>(buyerList);

    useEffect(() => {
        if (buyerList) setState(buyerList);
    },[buyerList]);

    const handleClick = (event: React.MouseEvent<unknown>, id: string | null | undefined) => {
        if (id) onSelect(id);
    };

    return (
    <>
        <h3>Buyer List</h3>
        <TableContainer component={Paper}>
        <Table className={classes.table} aria-label="simple table">
            <TableHead>
            <TableRow>
                <TableCell className={classes.columnHeader}>Buyer Name</TableCell>
            </TableRow>
            </TableHead>
            <TableBody>
            {state.map((row) => (
                <TableRow key={row.id}
                        tabIndex={-1}
                        onClick={(event) => handleClick(event, row.id)}>
                <TableCell component="th" scope="row">{row.name}</TableCell>
                </TableRow>
            ))}
            </TableBody>
        </Table>
        </TableContainer>
    </>
    );
};