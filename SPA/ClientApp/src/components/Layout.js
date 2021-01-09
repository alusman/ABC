import React, { Component } from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import Container from '@material-ui/core/Container';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <React.Fragment>
        <CssBaseline />
        <Container maxWidth="md">
          <div class="container-div">
            {this.props.children}
          </div>
        </Container>
      </React.Fragment>
    );
  }
}

