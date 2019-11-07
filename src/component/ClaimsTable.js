import React from 'react';
import ClaimRow from './ClaimRow.js';
import './ClaimsTable.css';

class ClaimsTable extends React.Component {

    /**
     * PROPS
     * type - Determines whether table for MyClaims or for All Claims.
     * 
     * Need to make it so that goes into another page if rows > 10
     */


    //Grabs correct table data from backend based on type prop
    getTableData = () => {

    }

    //Build table data
    //This will be replaced with loop when getTableData is working
    getTableRows = () => {
        let list = [];
        list.push(<ClaimRow
            claimNum="1"
            statusValue="1"
            dateTime="01/14/2019 3:22 PM"
            desc="New Desk"
            amt="500.00"
        />);
        list.push(<ClaimRow
            claimNum="2"
            statusValue="2"
            dateTime="02/01/2019 10:44 AM"
            desc="Hotel"
            amt="100.00"
        />);
        list.push(<ClaimRow
            claimNum="3"
            statusValue="3"
            dateTime="03/13/2019 01:01 PM"
            desc="Airfare"
            amt="255.00"
        />);
        list.push(<ClaimRow
            claimNum="4"
            statusValue="4"
            dateTime="07/11/2019 11:20 AM"
            desc="Cookies"
            amt="12.00"
        />);
        return list;
    }


    render() {
        return <table className="claims-table">
            <tr>
                <th>Claim<br/>Number</th>
                <th>Status</th>
                <th>Date & Time</th>
                <th>Description</th>
                <th>Amount</th>
                <th>Actions</th>
            </tr>
            {this.getTableRows()}
        </table>
    }
}

export default ClaimsTable;