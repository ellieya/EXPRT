import React from 'react';
import ClaimsTable from '../component/ClaimsTable.js';

class MyClaims extends React.Component {
    render() {
        return <div>
            <h1 className="page-title">My Claims</h1>
            <ClaimsTable type="mine"/>
        </div>
    }
}

export default MyClaims;