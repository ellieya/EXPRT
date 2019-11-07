import React from 'react';
import './StatusIcon.css';

class StatusIcon extends React.Component {

    getStatusName = () => {
        switch (parseInt(this.props.value)) {
            case 1:
                return "New";
            case 2:
                return "Approved";
            case 3:
                return "Needs Attention";
            case 4:
                return "Denied";
            default:
                //throw error
        }
    }

    getClassName = () => {
        switch (parseInt(this.props.value)) {
            case 1:
                return "new-icon";
            case 2:
                return "approve-icon";
            case 3:
                return "need-attention-icon";
            case 4:
                return "denied-icon";
            default:
                //throw error
        }
    }

    render() {
        return <span class={"status-icon " + this.getClassName()}>{this.getStatusName()}</span>
    }
}

export default StatusIcon;