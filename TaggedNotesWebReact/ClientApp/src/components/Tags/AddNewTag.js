﻿import React from 'react';

export class AddNewTag extends React.Component {
    constructor(props) {
        super(props);
        this.formRef = React.createRef();
        this.inputRef = React.createRef();
    }

    componentDidMount() {
        this.inputRef.current.focus();
    }

    onSubmit = (event) => {
        event.preventDefault();
        const newItemValue = this.inputRef.current.value;

        if (!newItemValue) { return; }

        const trimValue = newItemValue.trim();

        if (trimValue.length) {
            this.props.addItem({ name: newItemValue, id: this.props.getCount() + 1 });
            this.formRef.current.reset();
        }
    }

    render() {
        return (
            <form ref={this.formRef} onSubmit={this.onSubmit}>
                <div>
                    <input type="text" ref={this.inputRef} placeholder="<new tag name>"/>
                    <button type="submit">Add</button>
                </div>
            </form>
        );
    }
}