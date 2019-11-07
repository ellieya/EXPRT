import React from 'react';
import ClaimsTable from '../component/ClaimsTable.js';

class AllClaims extends React.Component {
    render() {
        return <div>
            <h1 className="page-title">All Claims</h1>
            <ClaimsTable type="all"/>
        </div>
    }
}

export default AllClaims;