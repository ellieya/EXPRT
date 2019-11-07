import React from 'react';
import './ActionButton.css';

class ActionButton extends React.Component {

    getButtonName = () => {
        switch (parseInt(this.props.value)) {
            case 1:
                return "View";
            case 2:
                return "View/Edit";
            case 3:
                return "Cancel";
            default:
                //throw error
        }
    }

    getClassName = () => {
        switch (parseInt(this.props.value)) {
            case 1:
            case 2:
                return "view-button";
            case 3:
                return "cancel-button";
            default:
                //throw error
        }
    }

    render() {
        return <span class={"action-icon " + this.getClassName()}>{this.getButtonName()}</span>
    }
}

export default ActionButton;