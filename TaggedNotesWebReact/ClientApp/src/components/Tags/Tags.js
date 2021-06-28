import React from 'react';
import { TagList } from './TagList';
import { AddNewTag } from './AddNewTag';

export class Tags extends React.Component {
    constructor(props) {
        super(props);
        this.state = { tags: props.items };

        this.saveTags = this.saveTags.bind(this);
    }

    addItem = tag => {
        const newList = [...this.state.tags, tag];
        this.setState({ tags: newList });
    }

    removeItem = id => {
        const newList = this.state.tags.filter(item => id !== item.id);
        this.setState({ tags: newList });
    }

    getCount = () => {
        return this.state.tags.length;
    }

    //todo: extract this method to a common method in a common component Editor (which will unite Notes and Tags components)
    saveTags() {
        fetch('tags', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(this.state.tags)
        }).then(function (response) {
            console.log(response);
        })
            .catch(function (error) {
                console.log(error);
            });
    }

    render() {
        return (
            <div>
                <button onClick={this.saveTags}>Save tags</button>
                <AddNewTag addItem={this.addItem} getCount={this.getCount} />
                <TagList items={this.state.tags} removeItem={this.removeItem} />
            </div>
        );
    }
}