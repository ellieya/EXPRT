import React from 'react';
import StatusIcon from './StatusIcon.js';
import ActionButton from './ActionButton.js';

class ClaimRow extends React.Component {
    
    /**
     * PROPS
     * 
     * claimNum
     * statusValue
     * dateTime
     * desc
     * amt
     */

    getActionButtons = () => {
        let list = [];
        switch (parseInt(this.props.claimNum)) {
            case 1:
            case 3:
                list.push(<ActionButton value={2} />);
                list.push(<ActionButton value={3} />);
                break;
            case 2:
            case 4:
                list.push(<ActionButton value={1} />)
                break;
            default:
                //throw error
                break;
        }

        return list;
    }

    render() {
        return <tr>
            <td>{this.props.claimNum}</td>
            <td><StatusIcon value={this.props.statusValue} /></td>
            <td>{this.props.dateTime}</td>
            <td>{this.props.desc}</td>
            <td>${this.props.amt}</td>
            <td>{this.getActionButtons()}</td>
        </tr>
    }
}

export default ClaimRow;