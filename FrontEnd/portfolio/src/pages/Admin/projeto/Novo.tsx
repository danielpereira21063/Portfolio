import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import { Container } from '@mui/system';
import { Card, Grid, Typography } from '@mui/material';

export default function NovoProjeto() {
    return (
        <Container maxWidth={'md'}>
            <Box
                marginY={'18px'}
                component="form"
                noValidate
                autoComplete="off"
            >
                <Card variant='elevation' style={{ padding: '16px' }}>
                    <Typography variant='h5' marginBottom={'24px'}>Novo projeto</Typography>

                    <Grid container spacing={{ xs: 2, md: 3 }} columns={{sm: 12 }}>
                        <Grid  item xs={2} sm={4} md={4} >
                            <TextField
                                label="Título"
                                defaultValue="Hello World"
                                size='small'
                            />

                            <TextField
                                label="Descrição"
                                defaultValue="Hello World"
                                helperText="Incorrect entry."
                                size='small'
                            />
                        </Grid>
                    </Grid>

                </Card>
            </Box>
        </Container>
    );
}
