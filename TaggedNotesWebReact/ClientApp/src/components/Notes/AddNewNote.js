import React from 'react';

/// class component - allows adding a new note
export class AddNewNote extends React.Component {
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
        const newItemValue = this.inputRef.current.value.trim();

        if (!newItemValue || this.props.notes.filter(e => e.text === newItemValue).length > 0) {
            return;
        }

        const trimValue = newItemValue.trim();

        if (trimValue.length) {
            this.props.addItem({ text: newItemValue, id: this.props.getMaxId() + 1 });
            this.formRef.current.reset();
        }
    }

    render() {
        return (
            <form ref={this.formRef} onSubmit={this.onSubmit}>
                <div>
                    <input type="text" ref={this.inputRef} placeholder="<new note text>"/>
                    <button type="submit">Add</button>
                </div>
            </form>
        );
    }
}