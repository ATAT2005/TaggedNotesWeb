import React from 'react';
import './../../custom.css';

export class TagItem extends React.Component {
    constructor(props) {
        super(props);
    }

    onClick = () => {
        this.props.removeItem(this.props.id);
    }

    render() {
        return (
            <tr class="tagcell">
                <td>{this.props.name}</td>
                <td><button size="small" onClick={this.onClick}>X</button></td>
            </tr>
        );
    }
}